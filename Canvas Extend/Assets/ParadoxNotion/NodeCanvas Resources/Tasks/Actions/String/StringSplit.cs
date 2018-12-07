using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("String")]
    [Description("Splits a string into substrings using separator characters.")]
    public class StringSplit : ActionTask
    {
        public BBParameter<string> valueA;
        public BBParameter<string> separators;
        public BBParameter<bool> trimStrings;
        public BBParameter<string> trimChars;
        [BlackboardOnly]
        public BBParameter<string[]> storeResult;
        protected override string info
        {
            get { return string.Format("{0}.Split({1})", valueA, separators); }
        }
        protected override void OnExecute()
        {
            var trimCharsArray = trimChars.value.ToCharArray();

            storeResult.value = valueA.value.Split(separators.value.ToCharArray());
            if (trimStrings.value)
            {
                for (var i = 0; i < storeResult.value.Length; i++)
                {
                    var s = storeResult.value[i] as string;
                    if (s == null) continue;
                    if(trimCharsArray.Length > 0)
                    {
                        storeResult.value[i] = s.Trim(trimCharsArray);
                    }else
                    {
                        storeResult.value[i] = s.Trim();
                    }                          
                }
            }
            EndAction();
        }
    }
}