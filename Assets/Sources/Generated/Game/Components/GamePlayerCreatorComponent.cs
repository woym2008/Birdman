//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly PlayerCreatorComponent playerCreatorComponent = new PlayerCreatorComponent();

    public bool isPlayerCreator {
        get { return HasComponent(GameComponentsLookup.PlayerCreator); }
        set {
            if (value != isPlayerCreator) {
                var index = GameComponentsLookup.PlayerCreator;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : playerCreatorComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPlayerCreator;

    public static Entitas.IMatcher<GameEntity> PlayerCreator {
        get {
            if (_matcherPlayerCreator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerCreator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerCreator = matcher;
            }

            return _matcherPlayerCreator;
        }
    }
}
