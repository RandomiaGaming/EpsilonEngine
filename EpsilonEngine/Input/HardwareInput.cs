﻿using System;
using System.Reflection;

namespace EpsilonEngine
{
    public sealed class HardwareInput
    {
        private InputManager _inputManager = null;
        private MethodInfo _sourceMethod = null;
        private RegisterHardwareInputAttribute _registerHardwareInputAttribute = null;
        private string _name = "Unnamed Hardware Input";
        private bool _pressed = false;
        public InputManager InputManager
        {
            get
            {
                return _inputManager;
            }
        }
        public MethodInfo SourceMethod
        {
            get
            {
                return _sourceMethod;
            }
        }
        public RegisterHardwareInputAttribute RegisterHardwareInputAttribute
        {
            get
            {
                return _registerHardwareInputAttribute;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public bool Pressed
        {
            get
            {
                return _pressed;
            }
        }
        private HardwareInput()
        {
            _inputManager = null;
            _sourceMethod = null;
            _registerHardwareInputAttribute = null;
            _name = "Unnamed Hardware Input";
        }
        public HardwareInput(InputManager inputManager, MethodInfo sourceMethod)
        {
            if (inputManager is null)
            {
                throw new Exception("inputManager cannot be null.");
            }
            _inputManager = inputManager;

            if (sourceMethod is null)
            {
                throw new Exception("sourceMethod was null.");
            }

            if (!sourceMethod.IsStatic)
            {
                throw new Exception("sourceMethod must be static.");
            }
            if (!sourceMethod.IsPublic)
            {
                throw new Exception("sourceMethod must be public.");
            }
            if (sourceMethod.IsConstructor)
            {
                throw new Exception("sourceMethod cannot be a constructor.");
            }
            if (sourceMethod.ReturnType != typeof(bool))
            {
                throw new Exception("sourceMethod must return a bool.");
            }
            if (sourceMethod.GetParameters().Length > 0)
            {
                throw new Exception("sourceMethod cannot have input parameters.");
            }
            _sourceMethod = sourceMethod;

            RegisterHardwareInputAttribute registerHardwareInputAttribute = _sourceMethod.GetCustomAttribute<RegisterHardwareInputAttribute>();
            if (registerHardwareInputAttribute is null)
            {
                throw new Exception("sourceMethod does not contain a RegisterHardwareInputAttribute");
            }
            _registerHardwareInputAttribute = registerHardwareInputAttribute;

            _name = registerHardwareInputAttribute.Name;
        }
        public void Update()
        {
            _pressed = (bool)_sourceMethod.Invoke(null, new object[0]);
        }
        public override string ToString()
        {
            return $"Epsilon.HardwareInput({_name})";
        }
        public static bool MethodIsHardwareInput(MethodInfo sourceMethod)
        {
            if (sourceMethod is null)
            {
                return false;
            }

            if (!sourceMethod.IsStatic)
            {
                return false;
            }
            if (!sourceMethod.IsPublic)
            {
                return false;
            }
            if (sourceMethod.IsConstructor)
            {
                return false;
            }
            if (sourceMethod.ReturnType != typeof(bool))
            {
                return false;
            }
            if (sourceMethod.GetParameters().Length > 0)
            {
                return false;
            }

            if (sourceMethod.GetCustomAttribute<RegisterHardwareInputAttribute>() is null)
            {
                throw new Exception("sourceMethod does not contain a RegisterHardwareInputAttribute");
            }

            return true;
        }
    }
}
