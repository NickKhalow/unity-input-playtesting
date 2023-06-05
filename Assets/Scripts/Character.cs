#nullable enable
using System;
using Constructors;
using Extensions;
using Inputs;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IConstructable<(AbstractInput? input, float? speed, int? health)>
{
    [SerializeField] private CharacterController controller = null!;
    [SerializeField] private float speed = 5;
    [SerializeField] private int health = 100;


    [SerializeField] private AbstractInput input = null!;

    public int Health => health;

    private void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>()!;
        }

        if (input == null)
        {
            throw new NullReferenceException("Input not found");
        }
    }

    private void Update()
    {
        controller.Move(Direction());
    }

    private Vector3 Direction()
    {
        var axis = input.Axis();
        var move = new Vector3(axis.x, 0, axis.y);
        return move * (speed * Time.deltaTime);
    }

    public void Construct((AbstractInput? input, float? speed, int? health) value)
    {
        if (value.input != null)
        {
            input = value.input;
        }

        input.EnsureNotNull("Input is not specified");
        speed = value.speed ?? speed;
        health = value.health ?? health;
    }

    public void Damage(int amount)
    {
        health -= amount;
    }
}