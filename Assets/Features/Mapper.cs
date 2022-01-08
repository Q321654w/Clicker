using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class Button : MonoBehaviour, IPointerDownHandler
    {
        public event Action<int> Pressed;

        [SerializeField] private int _id;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed?.Invoke(_id);
        }
    }

    public class AbilityInput : IEnumerable<Button>
    {
        private Button[] _buttons;
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public IEnumerator<Button> GetEnumerator()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                yield return _buttons[i];
            }
        }
    }

    public class Mapper
    {
        private Dictionary<int, Slot> _slots;

        public Ability GetAbility(int key)
        {
            if (!_slots.ContainsKey(key))
                throw new Exception("Slot not Binded");

            var slot = _slots[key];
            return slot.Ability;
        }
    }

    public class Slot
    {
        public event Action<Ability> Changed;

        public Ability Ability { get; set; }
    }

    public class Ability
    {
        public void Use()
        {
            throw new NotImplementedException();
        }
    }

    public class Player1
    {
        private Mapper _mapper;

        public Player1(AbilityInput input)
        {
            foreach (var button in input)
            {
                button.Pressed += UseAbility;
            }
        }

        public void UseAbility(int key)
        {
            var ability = _mapper.GetAbility(key);
            ability.Use();
        }
    }
}