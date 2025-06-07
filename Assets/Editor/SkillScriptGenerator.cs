using UnityEditor;
using UnityEngine;
using System.IO;
using System;

public class GenerateSkillBehaviourScripts
{
    [MenuItem("Tools/Generate Numbered SkillBehaviour Scripts")]
    public static void GenerateScripts()
    {
        string path = "Assets/01_Scripts/Skill";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        int index = 0;

     
        foreach (ElementType element in Enum.GetValues(typeof(ElementType)))
        {
            foreach (SkillGrade grade in Enum.GetValues(typeof(SkillGrade)))
            {
                string className = $"{element}{grade}";
                string fileName = $"{className}.cs";
                string filePath = Path.Combine(path, fileName);

                if (File.Exists(filePath))
                {
                    Debug.LogWarning($"{fileName} already exists. Skipping...");
                    index++;
                    continue;
                }

                string code =
$@"using UnityEngine;

public class {className} : ISkillBehaviour
{{
    public void Execute(SkillBase skill)
    {{
        Debug.Log(""{className} 발사!"");
    }}
}}";

                File.WriteAllText(filePath, code);
                index++;
            }
        }

        AssetDatabase.Refresh();
        Debug.Log("SkillBehaviour 스크립트 생성 완료!");
    }
}
