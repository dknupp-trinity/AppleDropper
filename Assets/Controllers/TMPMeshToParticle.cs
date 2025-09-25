using TMPro;
using UnityEngine;

public class TMPMeshToParticle : MonoBehaviour
{

    public TextMeshProUGUI DifficultyText;
    public ParticleSystem difficultyParticleSystem;
    
    
    public TextMeshProUGUI TimeText;
    public ParticleSystem timeParticleSystem;
    
    
    public TextMeshProUGUI ScoreText;
    public ParticleSystem scoreParticleSystem;
    
    
    public TextMeshProUGUI DropIntervalText;
    public ParticleSystem dropIntervalParticleSystem;
    
    
    public TextMeshProUGUI TreeSpeedText;
    public ParticleSystem treeSpeedParticleSystem;
    
    
    public TextMeshProUGUI GravityText;
    public ParticleSystem gravityParticleSystem;


    void Start()
    {
        // Force TMP to generate its mesh
        DifficultyText.ForceMeshUpdate();
        TimeText.ForceMeshUpdate();
        ScoreText.ForceMeshUpdate();
        DropIntervalText.ForceMeshUpdate();
        TreeSpeedText.ForceMeshUpdate();
        GravityText.ForceMeshUpdate();

        // Get the mesh
        Mesh difficultyTextMesh = DifficultyText.mesh;
        Mesh timeTextMesh = TimeText.mesh;
        Mesh scoreTextMesh = ScoreText.mesh;
        Mesh dropIntervalTextMesh = DropIntervalText.mesh;
        Mesh treeSpeedTextMesh = TreeSpeedText.mesh;
        Mesh gravityTextMesh = GravityText.mesh;


        // Assign it to the Particle System's Shape module
        var difficultyTextShape = difficultyParticleSystem.shape;
        difficultyTextShape.enabled = true;
        difficultyTextShape.shapeType = ParticleSystemShapeType.Mesh;
        difficultyTextShape.mesh = difficultyTextMesh;

        var timeTextShape = timeParticleSystem.shape;
        timeTextShape.enabled = true;
        timeTextShape.shapeType = ParticleSystemShapeType.Mesh;
        timeTextShape.mesh = timeTextMesh;

        var scoreTextShape = scoreParticleSystem.shape;
        scoreTextShape.enabled = true;
        scoreTextShape.shapeType = ParticleSystemShapeType.Mesh;
        scoreTextShape.mesh = scoreTextMesh;

        var dropIntervalTextShape = dropIntervalParticleSystem.shape;
        dropIntervalTextShape.enabled = true;
        dropIntervalTextShape.shapeType = ParticleSystemShapeType.Mesh;
        dropIntervalTextShape.mesh = dropIntervalTextMesh;

        var treeSpeedTextShape = treeSpeedParticleSystem.shape;
        treeSpeedTextShape.enabled = true;
        treeSpeedTextShape.shapeType = ParticleSystemShapeType.Mesh;
        treeSpeedTextShape.mesh = treeSpeedTextMesh;

        var gravityTextShape = gravityParticleSystem.shape;
        gravityTextShape.enabled = true;
        gravityTextShape.shapeType = ParticleSystemShapeType.Mesh;
        gravityTextShape.mesh = gravityTextMesh;
        
        
    }
}
