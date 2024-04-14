using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easteregg : MonoBehaviour
{



    [SerializeField] private bool _1 = false;
    [SerializeField] private bool _2 = false;
    [SerializeField] private bool _3 = false;
    [SerializeField] private bool _4 = false;
    [SerializeField] private bool _5 = false;
    [SerializeField] private bool _6 = false;
    [SerializeField] private bool _7 = false;

    [SerializeField] private GameObject _image;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_1)
        {
            if (_2)
            {
                if (_3)
                {
                    if (_4)
                    {
                        if (_5)
                        {
                            if (_6)
                            {
                                if (_7)
                                {
                                    _image.SetActive(true);
                                }
                            }
                            else if (_7)
                            {
                                _1 = false;
                                _2 = false;
                                _3 = false;
                                _4 = false;
                                _5 = false;
                                _6 = false;
                                _7 = false;
                            }
                        }
                        else if (_6||_7)
                        {
                            _1 = false;
                            _2 = false;
                            _3 = false;
                            _4 = false;
                            _5 = false;
                            _6 = false;
                            _7 = false;
                        }
                    } 
                    else if (_5||_6||_7)
                    {
                        _1 = false;
                        _2 = false;
                        _3 = false;
                        _4 = false;
                        _5 = false;
                        _6 = false;
                        _7 = false;
                    }
                }
                else if (_4||_5||_6||_7)
                {
                    _1 = false;
                    _2 = false;
                    _3 = false;
                    _4 = false;
                    _5 = false;
                    _6 = false;
                    _7 = false;
                }
            }
            else if (_3||_4||_5||_6||_7)
            {
                _1 = false;
                _2 = false;
                _3 = false;
                _4 = false;
                _5 = false;
                _6 = false;
                _7 = false;
            }
           
        }
    }

    public void active1()
    {
        _1 = true;
    }
    public void active2()
    {
        _2 = true;
    }
    public void active3()
    {
        _3 = true;
    }
    public void active4()
    {
        _4 = true;
    }
    public void active5()
    {
        _5 = true;
    }
    public void active6()
    {
        _6 = true;
    }
    public void active7()
    {
        _7 = true;
    }
    
    
}
