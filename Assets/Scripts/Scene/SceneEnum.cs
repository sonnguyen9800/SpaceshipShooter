
public enum SceneEnum {

    OpeningDialog,
    OpeningScene, 
    Campain1, 
}

public class Scene{
    
    //public static string LEVEL_1 = "1";

    public static string GetString(SceneEnum scene){
        return scene.ToString();
    }
}

