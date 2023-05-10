using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.UI;

// About this issue:
// 
// The effect of changing the time on RootMotion isn't eliminated when calling SetTime method twice on an AnimationClipPlayable.
// 
// How to reproduce:
// 1. Open the "SampleScene".
// 2. Enter play mode, and you will see the character walking in the Game view.
// 3. Click the "SetTime(0) twice" button in the Game view.
//    
// Expected result: The character’s position does not jump forward or back.
// Actual result: The character's position jumps forward or back.
// 
// Solution:
// https://forum.unity.com/threads/how-can-i-set-the-time-of-the-animationclipplayable-without-affecting-the-characters-position.1408411/#post-8907951


[RequireComponent(typeof(Animator))]
public class AnimPlayableSetTimeTest : MonoBehaviour
{
    public Text playableText;
    public Text positionText;
    public Text rotationText;
    public AnimationClip clip;

    private Animator _animator;
    private PlayableGraph _graph;
    private Playable _clipPlayable;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _graph = PlayableGraph.Create("Anim Playable SetTime Test");
        _graph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

        // _clipPlayable -> output
        _clipPlayable = AnimationClipPlayable.Create(_graph, clip);
        var output = AnimationPlayableOutput.Create(_graph, "Anim Output", _animator);
        output.SetSourcePlayable(_clipPlayable);

        _graph.Play();
    }

    private void LateUpdate()
    {
        playableText.text = $"Time: {_clipPlayable.GetTime()}";
        positionText.text = $"Position: {transform.position}";
        rotationText.text = $"Rotation: {transform.rotation.eulerAngles}";
    }

    private void OnDestroy()
    {
        _graph.Destroy();
    }

    public void SetTimeTwice(float time)
    {
        _clipPlayable.SetTime(time);
        _clipPlayable.SetTime(time);
    }
}