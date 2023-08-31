using UnityEngine.UIElements;
using UnityEditor;

[CustomPropertyDrawer(typeof(Trade))]
public class TradeCustomPropertyDrawer : PropertyDrawer
{
    StyleSheet ss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/Trade.uss");

    public override VisualElement CreatePropertyGUI(SerializedProperty property) {
        var root = Create("root");
        root.styleSheets.Add(ss);

        var label = Create<Label>("label");
        label.text = property.displayName;
        root.Add(label);

        var textParent = Create("text-parent");

        var inputField = Create<TextField>("input-field", "text-field");
        inputField.bindingPath = property.FindPropertyRelative("input").propertyPath;
        textParent.Add(inputField);

        var arrow = Create<Label>("arrow");
        arrow.text = "->";
        textParent.Add(arrow);

        var outputField = Create<TextField>("output-field", "text-field");
        outputField.bindingPath = property.FindPropertyRelative("output").propertyPath;
        textParent.Add(outputField);
        
        root.Add(textParent);

        return root;    
    }

    VisualElement Create(params string[] classNames) => Create<VisualElement>(classNames);

    T Create<T>(params string[] classNames) where T : VisualElement, new() {
        var instance = new T();
        foreach (var className in classNames) {
            instance.AddToClassList(className);
        }
        return instance;
    }
}
