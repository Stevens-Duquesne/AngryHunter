using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{

    public class OnKeyPressedEventArgs : EventArgs
    {
        public Vector3Int axe;

    }
    public class OnMouseTranslationEventArgs : EventArgs
    {
        public Vector2 mousePosition;
        public Vector2 translationMove; //Ancienne position
    }
    public class OnSpaceJumpEventArgs : EventArgs // Jump Event
    {
        public Vector3Int jumping;
    }
    public class OnMouseClicEventArgs : EventArgs
    {
        public bool MouseOnClic;
        public bool MouseClicState;
    }


    //Event Handlers declaration
    public EventHandler<OnKeyPressedEventArgs> _onKeyPressed;
    public EventHandler<OnMouseTranslationEventArgs> _onMousetranslate;
    public EventHandler<OnMouseClicEventArgs> _onMouseLeftClic;
    public EventHandler<OnSpaceJumpEventArgs> _onSpaceJump;

    private Vector2 OldMousePosition;



    private void OnKeyPressed(OnKeyPressedEventArgs args)
    {
        if (_onKeyPressed != null)
            _onKeyPressed(this, args);
    }
    private void OnMouseTranslate(OnMouseTranslationEventArgs args)
    {
        if (_onMousetranslate != null)
            _onMousetranslate(this, args);
    }
    private void OnMouseClic(OnMouseClicEventArgs args)
    {
        if (_onMouseLeftClic != null)
            _onMouseLeftClic(this, args);
    }
    private void OnSpaceJump(OnSpaceJumpEventArgs args)
    {
        if (_onSpaceJump != null)
            _onSpaceJump(this, args);
    }


    //Ici on check tous les keycodes relatifs aux déplacements, si au moins l'un d'entre eux est pressé, on appelle l'invocateur d'évènement en lui passant le paramètre créé à la volée contenant l'axe 
    public void Update()
    {
        //Movement keys
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        if (left || right || up || down)
        {
            OnKeyPressed(new OnKeyPressedEventArgs { axe = new Vector3Int(((left) ? -1 : 0 + ((right) ? 1 : 0)), 0, ((down) ? -1 : 0 + ((up) ? 1 : 0))) });

        }
        //Espace Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceJump(new OnSpaceJumpEventArgs { jumping = new Vector3Int(0, 5, 0) });
        }

        //Mouse Moves
        Vector2 newMousePosition = Input.mousePosition;
        Vector2 translationMove = newMousePosition - OldMousePosition;
        if (translationMove.magnitude != 0)
        {
            OnMouseTranslate(new OnMouseTranslationEventArgs { mousePosition = newMousePosition, translationMove = translationMove });
        }

        OldMousePosition = newMousePosition;


        //Mouse Clic
      
        if (Input.GetButtonDown("Fire1"))
        {
            bool mouseLeftButton = true;
            OnMouseClic(new OnMouseClicEventArgs { MouseOnClic = mouseLeftButton });
        }
        if (Input.GetButton("Fire1"))//clic
        {
            bool mouseLeftButton = true;
            OnMouseClic(new OnMouseClicEventArgs { MouseClicState = mouseLeftButton });

        }
        if (Input.GetButtonUp("Fire1"))//released
        {
            bool mouseLeftButton = false;
            OnMouseClic(new OnMouseClicEventArgs { MouseClicState = mouseLeftButton });
            OnMouseClic(new OnMouseClicEventArgs { MouseOnClic = mouseLeftButton });
        }

    }
}