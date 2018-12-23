using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using UnityEngine;
using System.Linq;

namespace NodeCanvas.Framework
{

    /// A Blackboard component to hold variables
    [CreateAssetMenu(menuName = "ParadoxNotion/Variables/Struct Asset")]
    [ParadoxNotion.Design.SpoofAOT]
    [System.Serializable]
    public class Struct : ScriptableObject, ISerializationCallbackReceiver, IBlackboard
    {

        public event System.Action<Variable> onVariableAdded;
        public event System.Action<Variable> onVariableRemoved;
        [SerializeField]
        private Struct _parent;
        [SerializeField]
        private string _serializedBlackboard = null;
        [SerializeField]
        private List<UnityEngine.Object> _objectReferences = null;
        [NonSerialized]
        private BlackboardSource _blackboard = new BlackboardSource();
        [NonSerialized]
        private bool hasDeserialized = false;
        [SerializeField]
        private bool _IsStatic;
        public bool IsStatic { get { return _IsStatic; } set { _IsStatic = value; } }
        public bool IsInstance { get; set; }
        public Struct Parent { get { return _parent; } set { _parent = value; } }
        private Struct _Static;
        public Struct Static
        {
            get
            {
                if (IsStatic && _Static == null)
                {
                    _Static = Clone();
                }
                return _Static;
            }
        }
        //serialize blackboard variables to json
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (JSONSerializer.applicationPlaying)
            {
                return;
            }

            if (_objectReferences != null && _objectReferences.Count > 0 && _objectReferences.Any(o => o != null))
            {
                hasDeserialized = false;
            }

            _objectReferences = new List<UnityEngine.Object>();
            _serializedBlackboard = JSONSerializer.Serialize(typeof(BlackboardSource), _blackboard, false, _objectReferences);
#endif
        }


        //deserialize blackboard variables from json
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (hasDeserialized && JSONSerializer.applicationPlaying)
            {
                return;
            }
            hasDeserialized = true;
            _blackboard = JSONSerializer.Deserialize<BlackboardSource>(_serializedBlackboard, _objectReferences);
            if (_blackboard == null) _blackboard = new BlackboardSource();
        }
        private void OnEnable()
        {
            if (Application.isPlaying && Parent != null
                && !Parent.IsInstance && !Parent.IsStatic)
            {
                Parent = Parent.Clone();
            }
            _blackboard.InitializePropertiesBinding(null, false);
        }
        new public string name
        {
            get { return string.IsNullOrEmpty(_blackboard.name) ? base.name + "_BB" : _blackboard.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = base.name + "_BB";
                }
                _blackboard.name = value;
            }
        }

        ///An indexer to access variables on the blackboard. It's recomended to use GetValue<T> instead
        public object this[string varName]
        {
            get
            {
                if (Parent == null)
                {
                    return _blackboard[varName];
                }
                else
                {
                    if (variables.ContainsKey(varName))
                    {
                        return _blackboard[varName];
                    }
                    else
                    {
                        return Parent[varName];
                    }
                }
            }
            set { SetValue(varName, value); }
        }

        ///The raw variables dictionary. It's highly recomended to use the methods available to access it though
        public Dictionary<string, Variable> variables
        {
            get { return _blackboard.variables; }
            set { _blackboard.variables = value; }
        }

        ///The GameObject target to do variable/property binding
        public GameObject propertiesBindTarget
        {
            get { return null; }
        }

        ///Add a new variable of name and type
        public Variable AddVariable(string name, Type type)
        {
            var variable = _blackboard.AddVariable(name, type);
            if (onVariableAdded != null)
            {
                onVariableAdded(variable);
            }
            return variable;
        }

        ///Add a new variable of name and value
        public Variable AddVariable(string name, object value)
        {
            var variable = _blackboard.AddVariable(name, value);
            if (onVariableAdded != null)
            {
                onVariableAdded(variable);
            }
            return variable;
        }

        ///Delete the variable with specified name
        public Variable RemoveVariable(string name)
        {
            var variable = _blackboard.RemoveVariable(name);
            if (onVariableRemoved != null)
            {
                onVariableRemoved(variable);
            }
            return variable;
        }

        ///Get a Variable of name and optionaly type
        public Variable GetVariable(string name, Type ofType = null)
        {
            Variable variable = _blackboard.GetVariable(name, ofType);
            if (variable == null && Parent != null)
            {
                variable = Parent.GetVariable(name, ofType);
            }
            return variable;

        }

        ///Get a Variable of ID and optionaly type
        public Variable GetVariableByID(string ID)
        {
            Variable variable = _blackboard.GetVariableByID(ID);
            if (variable == null && Parent != null)
            {
                variable = Parent.GetVariableByID(ID);
            }
            return variable;

        }

        //Generic version of get variable
        public Variable<T> GetVariable<T>(string name)
        {
            var variable = _blackboard.GetVariable<T>(name);
            if (variable == null && Parent != null)
            {
                variable = Parent.GetVariable<T>(name);
            }
            return variable;
        }

        ///Get the variable value of name
        public T GetValue<T>(string name)
        {
            if (_blackboard.variables.ContainsKey(name))
            {
                return _blackboard.GetValue<T>(name);
            }
            else if (Parent.variables.ContainsKey(name))
            {
                return Parent.GetValue<T>(name);
            }
            return default(T);
        }

        ///Set the variable value of name
        public Variable SetValue(string name, object value)
        {
            if (_blackboard.variables.ContainsKey(name))
            {
                return _blackboard.SetValue(name, value);
            }
            else if (Parent.variables.ContainsKey(name))
            {
                return Parent.SetValue(name, value);
            }
            return null;
        }

        ///Get all variable names
        public string[] GetVariableNames()
        {
            if (Parent != null)
            {
                List<string> VariableNames = new List<string>();
                VariableNames.AddRange(_blackboard.GetVariableNames());
                foreach (var name in Parent.GetVariableNames())
                {
                    if (!VariableNames.Contains(name))
                    {
                        VariableNames.Add(name);
                    }
                }
                return VariableNames.ToArray();
            }
            return _blackboard.GetVariableNames();
        }

        ///Get all variable names of type
        public string[] GetVariableNames(Type ofType)
        {
            if (Parent != null)
            {
                List<string> VariableNames = new List<string>();
                VariableNames.AddRange(_blackboard.GetVariableNames(ofType));
                foreach (var name in Parent.GetVariableNames(ofType))
                {
                    if (!VariableNames.Contains(name))
                    {
                        VariableNames.Add(name);
                    }
                }
                return VariableNames.ToArray();
            }
            return _blackboard.GetVariableNames(ofType);
        }

        ////////////////////
        //SAVING & LOADING//
        ////////////////////

        ///Saves the blackboard with the blackboard name as saveKey.
        public string Save() { return Save(this.name); }
        ///Saves the Blackboard in PlayerPrefs in the provided saveKey. You can use this for a Save system
        public string Save(string saveKey)
        {
            var json = this.Serialize();
            Dictionary<string, string> data = new Dictionary<string, string>();
            if (Parent != null)
            {
                data.Add("parent", Parent.Serialize());
            }
            data.Add("struct", json);
            var save = JSONSerializer.Serialize(typeof(Dictionary<string, string>), data, true);
            PlayerPrefs.SetString(saveKey, save);
            return save;
        }

        ///Loads a blackboard with this blackboard name as saveKey.
        public bool Load() { return Load(this.name); }
        ///Loads back the Blackboard from PlayerPrefs of the provided saveKey. You can use this for a Save system
        public bool Load(string saveKey)
        {

            var json = PlayerPrefs.GetString(saveKey);
            if (string.IsNullOrEmpty(json))
            {
                Debug.Log("No data to load blackboard variables from key " + saveKey);
                return false;
            }
            Dictionary<string, string> data = JSONSerializer.Deserialize<Dictionary<string, string>>(json);
            if (data == null) return false;
            if (Parent != null)
            {
                Parent.Deserialize(data["parent"]);
            }
            return this.Deserialize(data["struct"]);
        }


        ///Serialize the blackboard to json with optional list to store object references within.
        public string Serialize() { return Serialize(_objectReferences); }
        public string Serialize(List<UnityEngine.Object> storedObjectReferences)
        {
            return JSONSerializer.Serialize(typeof(BlackboardSource), _blackboard, false, storedObjectReferences);
        }

        ///Deserialize the blackboard from json with optional list of object references to read serialized object from.
        ///We deserialize ON TOP of existing variables so that external references to them stay intact.
        public bool Deserialize(string json) { return Deserialize(json, _objectReferences, true); }
        public bool Deserialize(string json, List<UnityEngine.Object> storedObjectReferences, bool removeMissing = true)
        {
            var bb = JSONSerializer.Deserialize<BlackboardSource>(json, storedObjectReferences);
            if (bb == null)
            {
                return false;
            }

            foreach (var pair in bb.variables)
            {
                if (_blackboard.variables.ContainsKey(pair.Key))
                {
                    _blackboard.SetValue(pair.Key, pair.Value.value);
                }
                else
                {
                    _blackboard.variables[pair.Key] = pair.Value;
                }
            }

            if (removeMissing)
            {
                var keys = new List<string>(_blackboard.variables.Keys);
                foreach (string key in keys)
                {
                    if (!bb.variables.ContainsKey(key))
                    {
                        _blackboard.variables.Remove(key);
                    }
                }
            }

            _blackboard.InitializePropertiesBinding(propertiesBindTarget, true);
            return true;
        }
        public Struct Clone(bool instance = true)
        {
            Struct newStruct = Instantiate(this);
            newStruct.name = newStruct.name.Replace("(Clone)", "");
            newStruct.IsInstance = instance;
            return newStruct;
        }
    }
}