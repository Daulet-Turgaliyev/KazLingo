using Client.Scripts.Data;
using Sirenix.OdinInspector;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace Editor
{


    public class MissionCreator : OdinMenuEditorWindow
    {
        [MenuItem("Tools/Custom Editor")]
        private static void OpenWindow()
        {
            GetWindow<MissionCreator>();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree
            {
                { "DragWordData", new DragWordEditor() },
                { "InputImageData", CreateInstance<InputImageData>() },
                { "InputSoundData", CreateInstance<InputSoundData>() },
                { "InputTextData", CreateInstance<InputTextData>() },
                { "InputWordData", CreateInstance<InputWordData>() },
                { "LessonData", CreateInstance<LessonData>() },
                { "MissionBaseData", CreateInstance<MissionBaseData>() },
                { "PutTogetherSentenceData", CreateInstance<PutTogetherSentenceData>() }
            };

            return tree;
        }
    }
}