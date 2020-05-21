using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cloner
{
    public static void ClonePlayer(GameObject _player, float _dissolveMulti = 5.0f)
    {
        // Clone the player and destroy scripts
        var go = GameObject.Instantiate(PlayerReferences.Inst.PlayerClone);

        // Get current animation from player
        var pa = _player.GetComponent<PlayerAnimator>();
        var state = pa.GetAnimationStateInfo();
        float t = state.normalizedTime;
        var clip = pa.GetAnimationClipInfo();
        var name = clip.clip.name;

        // Set the clone's animation
        var animClone = go.GetComponent<Animator>();
        animClone.speed = 0.0f;
        animClone.Play(name, 0, t);
        // Debug.Log(name + ", " + t);
        animClone.transform.position = _player.transform.position;
        animClone.transform.rotation = _player.transform.rotation;

        var clone = go.GetComponent<Clone>();
        clone.SpeedMulti = _dissolveMulti;
    }
}
