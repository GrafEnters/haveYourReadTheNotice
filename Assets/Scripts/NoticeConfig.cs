using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace{
    [CreateAssetMenu(fileName = "NoticeConfig", menuName = "ScriptableObjects/NoticeConfig")]
    public class NoticeConfig : ScriptableObject{
        [Multiline]
        public List<string> Texts;
    }
}