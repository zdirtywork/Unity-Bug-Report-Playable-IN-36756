# Unity-Bug-Report-Playable-IN-36756

## About this issue

The effect of changing the time on RootMotion isn't eliminated when calling SetTime method twice on an AnimationClipPlayable.

![Sample](./imgs~/img_sample.gif)

## How to reproduce

1. Open the "SampleScene".
2. Enter play mode, and you will see the character walking in the Game view.
3. Click the "SetTime(0) twice" button in the Game view.
   
Expected result: The character’s position does not jump forward or back.
Actual result: The character's position jumps forward or back.

## Solution

https://forum.unity.com/threads/how-can-i-set-the-time-of-the-animationclipplayable-without-affecting-the-characters-position.1408411/#post-8907951

![Compare-Top](./imgs~/img_compare_top.gif)

![Compare-Right](./imgs~/img_compare_right.gif)
