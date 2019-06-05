using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{

    public class OnKeyPressedEventArgs : EventArgs
    {
        public Vector2Int axe;

    }
    public class OnMouseTranslationEventArgs : EventArgs
    {
        public Vector2 mousePosition;
        public Vector2 translationMove; //Ancienne position
    }

    public class OnMouseClicEventArgs : EventArgs
    {
        public bool MouseClicState;
    }


    //Event Handlers declaration
    public EventHandler<OnKeyPressedEventArgs> _onKeyPressed;
    public EventHandler<OnMouseTranslationEventArgs> _onMousetranslate;
    public EventHandler<OnMouseClicEventArgs> _onMouseLeftClic;

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
            OnKeyPressed(new OnKeyPressedEventArgs { axe = new Vector2Int(((left) ? -1 : 0 + ((right) ? 1 : 0)), ((down) ? -1 : 0 + ((up) ? 1 : 0)))});
        }

        //Mouse Moves
        Vector2 newMousePosition = Input.mousePosition;
        Vector2 translationMove = newMousePosition - OldMousePosition;
        if (translationMove.magnitude != 0 )
        {
        OnMouseTranslate(new OnMouseTranslationEventArgs { mousePosition = newMousePosition, translationMove = translationMove });
        }

        OldMousePosition = newMousePosition;
        bool mouseLeftButton=false;

        //Mouse Clic
        if(Input.GetMouseButton(0))//clic
        {
            mouseLeftButton = true;
          OnMouseClic(new OnMouseClicEventArgs { MouseClicState = mouseLeftButton });
            
        }
        if (Input.GetMouseButtonUp(0))//released
        {
            mouseLeftButton = false;
            OnMouseClic(new OnMouseClicEventArgs { MouseClicState = mouseLeftButton });
        }

    }
}