using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateSkillDataAssets
{
    [MenuItem("Tools/Create All SkillData Assets")]
    public static void CreateAllSkillData()
    {
        string folderPath = "Assets/Resources/SO/Skill";
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        foreach (Skill skill in System.Enum.GetValues(typeof(Skill)))
        {
            SkillData asset = ScriptableObject.CreateInstance<SkillData>();

            asset.skillEnum = skill;

            string name = skill.ToString().ToLower();

            foreach (ElementType type in System.Enum.GetValues(typeof(ElementType)))
            {
                if (name.StartsWith(type.ToString().ToLower()))
                {
                    asset.elementType = type;
                    break;
                }
            }

            foreach (SkillGrade grade in System.Enum.GetValues(typeof(SkillGrade)))
            {
                if (name.EndsWith(grade.ToString().ToLower()))
                {
                    asset.grade = grade;
                    break;
                }
            }

            string assetName = $"Skill_{skill}.asset";
            AssetDatabase.CreateAsset(asset, Path.Combine(folderPath, assetName));
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }
}
