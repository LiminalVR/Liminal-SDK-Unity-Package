﻿using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Avatars.Controllers;
using Liminal.SDK.VR.Input;
using Liminal.SDK.VR.Pointers;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using Object = UnityEngine.Object;
using System.Linq;
using Liminal.SDK.VR.Devices.GearVR.Avatar;

namespace Liminal.SDK.XR
{
    public class UnityXRAvatar : MonoBehaviour, IVRDeviceAvatar
    {
        private IVRAvatar mAvatar;
        public IVRAvatar Avatar
        {
            get
            {
                if (mAvatar == null)
                { 
                    mAvatar = GetComponentInParent<IVRAvatar>();
                }

                return mAvatar;
            }
        }

        private bool IsHandControllerActive
        {
            get
            {
                if (OVRUtils.IsOculusQuest)
                    return OVRUtils.IsQuestControllerConnected;

                return false;// (OVRInput.GetActiveController() & GearVRController.AllHandControllersMask) != 0;
            }
        }

        private IVRDevice mDevice;

        private IVRTrackedObjectProxy mPrimaryControllerTracker;
        private IVRTrackedObjectProxy mSecondaryControllerTracker;
        
        // OVR
        private OVRManager mManager;
        private OVRCameraRig mCameraRig;

        protected void Awake()
        {
            Debug.Log($"[{GetType().Name}] XRSettings.loadedDeviceName: {XRSettings.loadedDeviceName}");

            mAvatar = GetComponentInParent<IVRAvatar>();
            mAvatar.InitializeExtensions();

            SetupControllers();

            mDevice = VRDevice.Device;
            //mSettings = gameObject.GetOrAddComponent<GearVRAvatarSettings>();
            //mGazeInput = GetComponent<GazeInput>();

            // Setup auxiliary systems
            SetupManager();
            SetupCameraRig();

            // Activate OVRManager once everything is setup
            mManager.gameObject.SetActive(true);

            // Load controller visuals for any VRAvatarController objects attached to the avatar
            {
                var avatarControllers = GetComponentsInChildren<VRAvatarController>(includeInactive: true);
                foreach (var controller in avatarControllers)
                {
                    AttachControllerVisual(controller);
                }
            }

            // Add event listeners
            mDevice.InputDeviceConnected += OnInputDeviceConnected;
            mDevice.InputDeviceDisconnected += OnInputDeviceDisconnected;
            mAvatar.Head.ActiveCameraChanged += OnActiveCameraChanged;
            SetupInitialControllerState();

            UpdateHandedness();
        }

        private void Update()
        {
            VRDevice.Device.Update();
        }

        private void SetupControllers()
        {
            if (XRSettings.loadedDeviceName == "oculus display")
            {
                switch (OVRPlugin.GetSystemHeadsetType())
                {
                    case OVRPlugin.SystemHeadset.None:
                        break;
                    case OVRPlugin.SystemHeadset.GearVR_R320:
                    case OVRPlugin.SystemHeadset.GearVR_R321:
                    case OVRPlugin.SystemHeadset.GearVR_R322:
                    case OVRPlugin.SystemHeadset.GearVR_R323:
                    case OVRPlugin.SystemHeadset.GearVR_R324:
                    case OVRPlugin.SystemHeadset.GearVR_R325:
                        // OVRUtils.IsGearVRHeadset()
                        break;
                    case OVRPlugin.SystemHeadset.Oculus_Go:
                        // OVRUtils.IsOculusGo
                        SetupForOculusGo();
                        break;
                    case OVRPlugin.SystemHeadset.Oculus_Quest:
                        // OVRUtils.IsOculusQuest
                        SetupForOculusQuest();
                        break;
                    case OVRPlugin.SystemHeadset.Rift_DK1:
                    case OVRPlugin.SystemHeadset.Rift_DK2:
                    case OVRPlugin.SystemHeadset.Rift_CV1:
                    case OVRPlugin.SystemHeadset.Rift_CB:
                    case OVRPlugin.SystemHeadset.Rift_S:
                    default:
                        break;
                }
            }
        }

        private void SetupForGearVR()
        {
            throw new NotImplementedException();

            mPrimaryControllerTracker = new GearVRTrackedControllerProxy(mAvatar, VRAvatarLimbType.RightHand);
            mSecondaryControllerTracker = new GearVRTrackedControllerProxy(mAvatar, VRAvatarLimbType.LeftHand);
        }

        private void SetupForOculusGo()
        {
            throw new NotImplementedException();
        }

        private void SetupForOculusQuest()
        {
            throw new NotImplementedException();
        }

        private void SetupManager()
        {
            throw new NotImplementedException();
            //if (OVRManager.instance == null)
            //{
            //    Debug.Log("[GearVR] Adding OVRManager");
            //    var go = new GameObject("OVRManager");
            //    mManager = go.AddComponent<OVRManager>();
            //    DontDestroyOnLoad(go);
            //}
            //else
            //{
            //    mManager = OVRManager.instance;
            //}
        }

        private void SetupCameraRig()
        {
            throw new NotImplementedException();
            //var cameraRigPrefab = VRAvatarHelper.EnsureLoadPrefab<GearVRCameraRig>("GearVRCameraRig");
            //cameraRigPrefab.gameObject.SetActive(false);
            //mCameraRig = Instantiate(cameraRigPrefab);
            //mCameraRig.transform.SetParentAndIdentity(mAvatar.Auxiliaries);

            //OnActiveCameraChanged(mAvatar.Head);
        }

        private void SetupInitialControllerState()
        {
            throw new NotImplementedException();
            //if (mDevice.InputDevices.Any(x => x is GearVRController))
            //{
            //    foreach (var controller in mDevice.InputDevices)
            //    {
            //        EnableController(controller as GearVRController);
            //    }
            //}
            //else
            //{
            //    // Disable controllers and enable gaze controls
            //    DisableAllControllers();
            //}
        }

        private void AttachControllerVisual(VRAvatarController avatarController)
        {
            throw new NotImplementedException();
            //var limb = avatarController.GetComponentInParent<IVRAvatarLimb>();

            //var prefab = VRAvatarHelper.EnsureLoadPrefab<VRControllerVisual>(ControllerVisualPrefabName);
            //prefab.gameObject.SetActive(false);

            //// Create controller instance
            //var instance = Instantiate(prefab);
            //instance.name = prefab.name;
            //instance.transform.SetParentAndIdentity(avatarController.transform);

            //// Make sure the OVRGearVrController component exists...
            //var trackedRemote = instance.gameObject.GetComponent<OVRControllerHelper>();

            //if (trackedRemote == null)
            //    trackedRemote = instance.gameObject.AddComponent<OVRControllerHelper>();

            //avatarController.ControllerVisual = instance;
            //mRemotes.Add(trackedRemote);

            //// Assign the correct controller based on the limb type the controller is attached to
            //OVRInput.Controller controllerType = GetControllerTypeForLimb(limb);
            //trackedRemote.m_controller = controllerType;
            //trackedRemote.m_modelGearVrController.SetActive(true);

            //// Activate the controller
            //// TODO Do we need to set active here? 
            //var active = OVRUtils.IsLimbConnected(limb.LimbType);
            //instance.gameObject.SetActive(active);

            //Debug.Log($"Attached Controller: {limb.LimbType} and SetActive: {active} Controller Type set to: {controllerType}");
        }

        #region Controllers
        // TODO See if this method can be removed, it appears to not be used at all and it can be misleading when debugging.
        /// <summary>
        /// Instantiates a <see cref="VRControllerVisual"/> for a limb.
        /// </summary>
        /// <param name="limb">The limb for the controller.</param>
        /// <returns>The newly instantiated controller visual for the specified limb, or null if no controller visual was able to be created.</returns>
        public VRControllerVisual InstantiateControllerVisual(IVRAvatarLimb limb)
        {
            throw new NotImplementedException();

            //if (limb == null)
            //    throw new ArgumentNullException("limb");

            //if (limb.LimbType == VRAvatarLimbType.Head)
            //    return null;

            //var prefab = VRAvatarHelper.EnsureLoadPrefab<VRControllerVisual>(ControllerVisualPrefabName);
            //var instance = Instantiate(prefab);

            //var ovrController = instance.GetComponent<OVRControllerHelper>();
            //ovrController.m_controller = GetControllerTypeForLimb(limb);
            //ovrController.m_modelGearVrController.SetActive(true);
            //ovrController.enabled = false;

            //instance.gameObject.SetActive(true);
            //return instance;

        }

        //private void EnableController(GearVRController controller)
        //{
        //    throw new NotImplementedException();

        //    //if (controller == null)
        //    //    return;

        //    //// Find the visual for the hand that matches the controller
        //    //var remote = mRemotes.FirstOrDefault(x => (x.m_controller & controller.ControllerMask) != 0);
        //    //if (remote != null)
        //    //    remote.gameObject.SetActive(true);
        //}

        private void DisableAllControllers()
        {
            throw new NotImplementedException();
            //// Disable all controller visuals
            //foreach (var remote in mRemotes)
            //{
            //    remote.gameObject.SetActive(false);
            //}
        }

        #endregion

        private void UpdateHandedness()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Detects and Updates the state of the controllers including the TouchPad on the GearVR headset
        /// </summary>
        public void DetectAndUpdateControllerStates()
        {
            TrySetLimbsActive();
            TrySetGazeInputActive(!IsHandControllerActive);
        }

        /// <summary>
        /// A temporary method to split Oculus Quest changes with the other devices. 
        /// </summary>
        private void TrySetLimbsActive()
        {
            if (OVRUtils.IsOculusQuest)
            {
                TrySetHandActive(VRAvatarLimbType.RightHand);
                TrySetHandActive(VRAvatarLimbType.LeftHand);
            }
            else
            {
                TrySetHandsActive(IsHandControllerActive);
            }
        }

        private void TrySetHandActive(VRAvatarLimbType limbType)
        {
            var isLimbConnected = OVRUtils.IsLimbConnected(limbType);
            var limb = mAvatar.GetLimb(limbType);

            limb.SetActive(isLimbConnected);
        }

        private void TrySetHandsActive(bool active)
        {
            throw new NotImplementedException();
            //if (mAvatar != null)
            //{
            //    if (OVRUtils.IsGearVRHeadset())
            //    {
            //        if (OVRInput.GetActiveController() == OVRInput.Controller.Touchpad)
            //            active = false;
            //    }

            //    mAvatar.SetHandsActive(active);
            //}
        }

        private void TrySetGazeInputActive(bool active)
        {
            throw new NotImplementedException();
            // Ignore Always & Never Policy
            //if (mGazeInput != null && mGazeInput.ActivationPolicy == GazeInputActivationPolicy.NoControllers)
            //{
            //    if (active)
            //        mGazeInput.Activate();
            //    else
            //        mGazeInput.Deactivate();
            //}
        }

        private void RecenterHmdIfRequired()
        {
            throw new NotImplementedException();
            //if (mSettings != null && mSettings.HmdRecenterPolicy != HmdRecenterPolicy.OnControllerRecenter)
            //    return;

            //if (OVRInput.GetControllerWasRecentered())
            //{
            //    // Recenter the camera when the user recenters the controller
            //    UnityEngine.XR.InputTracking.Recenter();
            //}
        }

        private OVRInput.Controller GetControllerTypeForLimb(IVRAvatarLimb limb)
        {
            if (limb.LimbType == VRAvatarLimbType.LeftHand)
                return OVRInput.Controller.LTouch;

            if (limb.LimbType == VRAvatarLimbType.RightHand)
                return OVRInput.Controller.RTouch;

            return OVRInput.Controller.None;
        }

        #region Event Handlers

        //Notes: Device Connecting is difference than controller being active
        private void OnInputDeviceConnected(IVRDevice vrDevice, IVRInputDevice inputDevice)
        {
            throw new NotImplementedException();
            //var gearController = inputDevice as GearVRController;
            //if (gearController != null)
            //{
            //    // A controller was connected
            //    // Disable gaze controls
            //    EnableController(gearController);
            //}
        }

        private void OnInputDeviceDisconnected(IVRDevice vrDevice, IVRInputDevice inputDevice)
        {
            throw new NotImplementedException();
            //if (!vrDevice.InputDevices.Any(x => x is GearVRController))
            //{
            //    // No controllers are connected
            //    // Enable gaze controls
            //    DisableAllControllers();
            //}
        }

        private void OnActiveCameraChanged(IVRAvatarHead head)
        {
            if (mCameraRig != null)
            {
                mCameraRig.usePerEyeCameras = head.UsePerEyeCameras;
            }
        }
        #endregion
    }

    /// <summary>
    /// Mappings and further manual information available here: https://docs.unity3d.com/Manual/xr_input.html
    /// All of the below are on a per-controller basis and may or may not exist depending on the platform that it currently running
    /// 
    /// Buttons:
    /// - primaryButton
    /// - secondaryButton
    /// - secondaryTouch
    /// - gripButton
    /// - triggerButton
    /// - menuButton
    /// - primary2DAxisClick
    /// - primary2DAxisTouch
    /// - userPresence (WMR, Oculus)
    /// 
    /// Axis:
    /// - trigger
    /// - grip
    /// - batteryLevel (only WMR)
    /// 
    /// 2D Axis:
    /// - primary2DAxis
    /// - secondary2DAxis
    /// </summary>
    public class UnityXRInputDevice : IVRInputDevice
    {
        #region Inner enums
        public enum EPressState
        {
            None,
            Down,
            Pressing,
            Up
        } 
        #endregion

        #region InputFeature inner classes
        public abstract class InputFeature
        {
            protected InputDevice? Device { get; private set; }
            public EPressState PressState { get; protected set; }
            public abstract string Name { get; }

            public InputFeature()
            {
                PressState = EPressState.None;
            }

            public void AssignDevice(InputDevice aDevice)
            {
                if (Device.HasValue) return;

                Device = aDevice;
            }

            public abstract void UpdateState();
        }

        public abstract class InputFeature<T> : InputFeature where T : IEquatable<T>
        {
            // RawValue is assigned, also assign the 'normalised' Value
            public virtual T RawValue 
            {
                get; protected set;
            }
            public T Value { get; protected set; }

            public InputFeatureUsage<T> BaseFeature { get; }

            public override string Name => BaseFeature.name;

            public InputFeature(InputFeatureUsage<T> aBaseFeature) : base()
            {
                BaseFeature = aBaseFeature;
            }
        }

        public class ButtonInputFeature : InputFeature<bool>
        {
            public override bool RawValue
            { 
                get => base.RawValue;
                protected set
                {
                    base.RawValue = value;
                    Value = RawValue;
                }
            }

            public ButtonInputFeature(InputFeatureUsage<bool> aBaseFeature) : base(aBaseFeature)
            {
            }

            public override void UpdateState()
            {
                if (!Device.HasValue) return;

                if (!Device.Value.TryGetFeatureValue(BaseFeature, out bool isPressed))
                {
                    // couldn't get input for the feature, so mark press state as none
                    PressState = EPressState.None;
                    RawValue = false;
                }

                // received a value, so update accordingly
                EPressState currentState = PressState;
                RawValue = isPressed;

                if (isPressed)
                {
                    switch (currentState)
                    {
                        case EPressState.None:
                            PressState = EPressState.Down;
                            break;
                        case EPressState.Down:
                            PressState = EPressState.Pressing;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (currentState)
                    {
                        case EPressState.Pressing:
                            PressState = EPressState.Up;
                            break;
                        case EPressState.Up:
                            PressState = EPressState.None;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public interface AxisInputFeature { }

        public class Axis1DInputFeature : InputFeature<float>, AxisInputFeature
        {
            private const float THRESHOLD = 0.1f;

            public override float RawValue
            { 
                get => base.RawValue;
                protected set
                {
                    base.RawValue = value;
                    Value = value >= THRESHOLD ? 1f : 0f;
                }
            }

            public Axis1DInputFeature(InputFeatureUsage<float> aBaseFeature) : base(aBaseFeature)
            {
            }

            public override void UpdateState()
            {
                if (!Device.HasValue) return;

                if (!Device.Value.TryGetFeatureValue(BaseFeature, out float rawActuated))
                {
                    // couldn't get input for the feature, so mark press state as none
                    PressState = EPressState.None;
                    RawValue = 0.0f;
                }

                // received a value, so update accordingly
                EPressState currentState = PressState;
                RawValue = rawActuated;

                // if above or equal to the threshold the axis is considered 'pressed'
                if (rawActuated >= THRESHOLD)
                {
                    switch (currentState)
                    {
                        case EPressState.None:
                            PressState = EPressState.Down;
                            break;
                        case EPressState.Down:
                            PressState = EPressState.Pressing;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (currentState)
                    {
                        case EPressState.Pressing:
                            PressState = EPressState.Up;
                            break;
                        case EPressState.Up:
                            PressState = EPressState.None;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public class Axis2DInputFeature : InputFeature<Vector2>, AxisInputFeature
        {
            private const float THRESHOLD = 0.1f;

            public override Vector2 RawValue
            {
                get => base.RawValue;
                protected set
                {
                    base.RawValue = value;

                    Value = new Vector2(
                        Mathf.Abs(base.RawValue.x) >= THRESHOLD ? 1f * Mathf.Sign(base.RawValue.x) : 0f,
                        Mathf.Abs(base.RawValue.y) >= THRESHOLD ? 1f * Mathf.Sign(base.RawValue.y) : 0f
                    );
                }
            }

            public Axis2DInputFeature(InputFeatureUsage<Vector2> aBaseFeature) : base(aBaseFeature)
            {
            }

            public override void UpdateState()
            {
                if (!Device.HasValue) return;

                if (!Device.Value.TryGetFeatureValue(BaseFeature, out Vector2 rawActuated))
                {
                    // couldn't get input for the feature, so mark press state as none
                    PressState = EPressState.None;
                    RawValue = Vector2.zero;
                }

                // received a value, so update accordingly
                EPressState currentState = PressState;
                RawValue = rawActuated;

                // if either axis exceeds the threshold, considered pressed
                if (Mathf.Abs(rawActuated.x) >= THRESHOLD ||
                    Mathf.Abs(rawActuated.y) >= THRESHOLD)
                {
                    switch (currentState)
                    {
                        case EPressState.None:
                            PressState = EPressState.Down;
                            break;
                        case EPressState.Down:
                            PressState = EPressState.Pressing;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (currentState)
                    {
                        case EPressState.Pressing:
                            PressState = EPressState.Up;
                            break;
                        case EPressState.Up:
                            PressState = EPressState.None;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        public string Name => "UnityController";
        public IVRPointer Pointer { get; }

        // TODO: Confirm this?
        public int ButtonCount => 3;
        public VRInputDeviceHand Hand { get; }

        // this is mapped to 'primaryTouch' inputFeature
        public bool IsTouching { get => GetButton(VRButton.Touch); }

        private static readonly VRInputDeviceCapability _capabilities = VRInputDeviceCapability.DirectionalInput |
                                                                        VRInputDeviceCapability.Touch |
                                                                        VRInputDeviceCapability.TriggerButton;

        private Dictionary<string, InputFeature> _inputFeatures = new Dictionary<string, InputFeature>
        {
            // buttons
            { VRButton.Back, new ButtonInputFeature(CommonUsages.secondaryButton) },
            { VRButton.Touch, new ButtonInputFeature(CommonUsages.primaryTouch) },
            { VRButton.Trigger, new ButtonInputFeature(CommonUsages.triggerButton) },
            { VRButton.Primary, new ButtonInputFeature(CommonUsages.primaryButton) },
            { VRButton.Seconday, new ButtonInputFeature(CommonUsages.gripButton) },
            { VRButton.Three, new ButtonInputFeature(CommonUsages.primary2DAxisTouch) },
            { VRButton.Four, new ButtonInputFeature(CommonUsages.primary2DAxisClick) },

            // axis 2D
            { VRAxis.One, new Axis2DInputFeature(CommonUsages.primary2DAxis) },

            // axis 1D
            { VRAxis.Two, new Axis1DInputFeature(CommonUsages.trigger) },
            { VRAxis.Three, new Axis1DInputFeature(CommonUsages.grip) },
        };

        public UnityXRInputDevice(VRInputDeviceHand hand)
        {
            Hand = hand;
            Pointer = new InputDevicePointer(this);
            Pointer.Activate();

            foreach (var pairs in _inputFeatures.ToArray())
            {
                InputFeature inputFeature = pairs.Value;

                // also register axes with their raw counterpart
                if (inputFeature is AxisInputFeature && !pairs.Key.EndsWith("Raw"))
                {
                    string rawKey = $"{pairs.Key}Raw";

                    if (!_inputFeatures.ContainsKey(rawKey))
                    {
                        _inputFeatures.Add(rawKey, inputFeature);
                    }
                }

                inputFeature.AssignDevice(InputDevice);
            }
        }

        public UnityXRInputDevice()
        {
        }

        public InputDevice InputDevice => InputDevices.GetDeviceAtXRNode(Hand == VRInputDeviceHand.Right ? XRNode.RightHand : XRNode.LeftHand);

        public bool HasCapabilities(VRInputDeviceCapability capabilities)
        {
            return ((_capabilities & capabilities) == capabilities);
        }

        public bool HasAxis1D(string axis)
        {
            return _inputFeatures.TryGetValue(axis, out var feature) && feature is Axis1DInputFeature;
        }

        public bool HasAxis2D(string axis)
        {
            return _inputFeatures.TryGetValue(axis, out var feature) && feature is Axis2DInputFeature;
        }

        public bool HasButton(string button)
        {
            return _inputFeatures.TryGetValue(button, out var feature) && feature is ButtonInputFeature;
        }

        public float GetAxis1D(string axis)
        {
            if (!HasAxis1D(axis)) return 0f;

            var axis1DFeature = _inputFeatures[axis] as Axis1DInputFeature;
            return axis.Contains("Raw") ? axis1DFeature.RawValue : axis1DFeature.Value;
        }

        public Vector2 GetAxis2D(string axis)
        {
            if (!HasAxis2D(axis)) return Vector2.zero;

            var axis2DFeature = _inputFeatures[axis] as Axis2DInputFeature;
            return axis.Contains("Raw") ? axis2DFeature.RawValue : axis2DFeature.Value;
        }

        public bool GetButton(string button)
        {
            return GetButtonState(button) == EPressState.Pressing;
        }

        public bool GetButtonDown(string button)
        {
            return GetButtonState(button) == EPressState.Down;
        }

        public bool GetButtonUp(string button)
        {
            return GetButtonState(button) == EPressState.Up;
        }

        public EPressState GetButtonState(string button)
        {
            if (!HasButton(button)) return EPressState.None;

            var buttonFeature = _inputFeatures[button] as ButtonInputFeature;
            return buttonFeature.PressState;
        }

        public void Update()
        {
            // foreach input registered
            foreach (var feature in _inputFeatures.Values)
            {
                // update it
                try
                {
                    feature.UpdateState();
                }
                catch (Exception)
                {
                    Debug.LogError($"Problems occuring within {feature.Name}");
                }
            }
        }
    }

    public class UnityXRHeadset : IVRHeadset
    {
        private static readonly VRHeadsetCapability _capabilities = VRHeadsetCapability.PositionalTracking | VRHeadsetCapability.PositionalTracking;

        public string Name => "UnityXRHeadset";
        public IVRPointer Pointer { get; }

        public bool HasCapabilities(VRHeadsetCapability capabilities)
        {
            return (_capabilities & capabilities) == capabilities;
        }
    }

    public class UnityXRDevice : IVRDevice
    {
        private static readonly VRDeviceCapability _capabilities = VRDeviceCapability.Controller | VRDeviceCapability.UserPrescenceDetection;
        
        public string Name => "UnityXR";
        public int InputDeviceCount => 2;

        public IVRHeadset Headset => new UnityXRHeadset();
        public IEnumerable<IVRInputDevice> InputDevices { get; }

        public IVRInputDevice PrimaryInputDevice { get; }
        public IVRInputDevice SecondaryInputDevice { get; }

        public List<UnityXRInputDevice> XRInputs = new List<UnityXRInputDevice>();

        public int CpuLevel { get; set; }
        public int GpuLevel { get; set; }

        public event VRInputDeviceEventHandler InputDeviceConnected;
        public event VRInputDeviceEventHandler InputDeviceDisconnected;
        public event VRDeviceEventHandler PrimaryInputDeviceChanged;

        public UnityXRDevice()
        {
            var primary = new UnityXRInputDevice(VRInputDeviceHand.Right);
            var secondary = new UnityXRInputDevice(VRInputDeviceHand.Left);

            PrimaryInputDevice = primary;
            SecondaryInputDevice = secondary;

            XRInputs.Add(primary);
            XRInputs.Add(secondary);

            InputDevices = new List<IVRInputDevice>
            {
                PrimaryInputDevice,
                SecondaryInputDevice,
            };
        }

        public bool HasCapabilities(VRDeviceCapability capabilities)
        {
            return (_capabilities & capabilities) == capabilities;
        }

        public void SetupAvatar(IVRAvatar avatar)
        {
            avatar.Transform.gameObject.AddComponent<UnityXRAvatar>();
            var manager = new GameObject().AddComponent<XRInteractionManager>();
            
            var avatarGo = avatar.Transform.gameObject;
            
            var xrRig = avatarGo.AddComponent<XRRig>();
            var centerEye = avatar.Head.CenterEyeCamera.gameObject;
            var eyeDriver = centerEye.AddComponent<TrackedPoseDriver>();
            eyeDriver.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
            eyeDriver.SetPoseSource(TrackedPoseDriver.DeviceType.GenericXRDevice, TrackedPoseDriver.TrackedPose.Center);
            xrRig.cameraGameObject = centerEye.gameObject;
            xrRig.TrackingOriginMode = TrackingOriginModeFlags.Floor;

            var primaryHandPrefab = Resources.Load("RightHand Controller");
            var primaryHand = Object.Instantiate(primaryHandPrefab, avatar.Transform) as GameObject;

            var secondaryHandPrefab = Resources.Load("LeftHand Controller");
            var secondaryHand = Object.Instantiate(secondaryHandPrefab, avatar.Transform) as GameObject;

            avatar.PrimaryHand.Transform.SetParent(primaryHand.transform);
            var primaryPointer = primaryHand.GetComponentInChildren<LaserPointerVisual>();

            if (primaryPointer != null)
                PrimaryInputDevice.Pointer.Transform = primaryPointer.transform;

            primaryPointer?.Bind(PrimaryInputDevice.Pointer);
            avatar.SecondaryHand.Transform.SetParent(secondaryHand.transform);

            var secondaryPointer = secondaryHand.GetComponentInChildren<LaserPointerVisual>();
            secondaryPointer?.Bind(SecondaryInputDevice.Pointer);

            if (secondaryPointer != null)
                SecondaryInputDevice.Pointer.Transform = secondaryPointer.transform;

            avatar.Head.Transform.localPosition = Vector3.zero;
            //UpdateConnectedControllers();
            //SetDefaultPointerActivation();
        }

        public void Update()
        {
            foreach (var input in XRInputs)
            {
                input.Update();
            }
        }
    }
}