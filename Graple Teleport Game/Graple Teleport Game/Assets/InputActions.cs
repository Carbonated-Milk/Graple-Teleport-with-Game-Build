// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""3a583f7d-7284-4236-b690-d4a5ee9e44cd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dace67a2-5942-451e-8597-9bffc98e3ff1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ea3c4594-923c-44ee-9ddc-84cfa622d9d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""f3d9477b-183e-44d1-a8df-32f00c6c1b24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""3153fc52-4e10-4d99-b307-42b400a540a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""f1afaa4b-de94-474a-955e-93557f372a67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""411639a9-c4eb-499d-bcbf-48d2c8e91fa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ceec11a-e679-4aa6-bdba-04fbb1ebc9bb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""0bbbdab0-1100-41f1-a0a4-ee00af4adef6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""584ec3be-96b4-4923-a4ee-c2c4de680c0a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f315dee8-46d2-4a01-ac72-5085c51dbb12"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""86f3bad7-cb33-4dac-89f7-88f546daf7ce"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4eb4f51f-cc92-42b9-ac76-3baf221c53c6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6d8f10e5-39dc-4fc2-8088-a3f508437aa3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bdf95fc-4e9c-40b0-8662-eb2877141edf"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;Controller"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""486b5d81-3733-47cf-a204-b70b42fb6b2d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04ef8cef-756e-4bdd-aba0-c2aa781f2c58"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player1"",
            ""id"": ""c4b890db-1b27-4a3d-8bde-8de1145302e4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c2079823-ceed-4145-8a15-95c57e459e1b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d6878c3d-b9ab-4a91-a9c1-80f401d99282"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""a7fbdbc2-8dc4-4e12-97aa-ecd8eac66c0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""6c306295-1380-4d92-a6f2-1788891bfaa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""8587063f-e9e3-429a-8a31-c062480bd204"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9f03b8dd-6e1f-4492-81c2-7edc5fdbf868"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1e958f6-1223-4943-b562-5670731758fd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60d8ffdf-73b4-490a-9bc9-f53cffcc8bd4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc6f0520-9c6d-4605-a94d-34e59c36fc53"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42ab6b2e-6fe0-4c2b-824a-7afc1af03b60"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""d346d3cf-1573-4994-b54b-5319da4baa23"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e9c07ca2-4e15-4e65-8fee-0a3d85b9f2af"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""52edaad9-7d8a-4a07-a0f9-c06e500c845d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""757b7227-792c-4154-909a-2ee06091275d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""44c4e4ea-b20c-498e-bc2f-01693b65324c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ae41453a-ce15-410d-8b7f-4058c28a486f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af5947b9-eea0-418f-99c0-c161e9a1b7ee"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8288b218-22ea-4084-b981-0ce3cf65e1f0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""93316af5-727f-4cb3-9ad3-53ec1eabadb7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d4c47afc-3692-4795-ae6a-3ddd2b4fc131"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0a177c5e-579a-4ed8-8f42-9f47b3dfc23e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3751a1be-31fa-428f-98f8-5a1714429253"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4500e398-cff0-4eb1-8ff1-fbaab5bc5412"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0287cf5f-a68c-4036-af50-dfaab4c6d66e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a7f3db9-b527-41c8-af2c-0b9f09dc30d4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a571fb5-845a-4612-adbf-3b9a2bc089fb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;Controller"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player3"",
            ""id"": ""20259211-6ebb-4ff0-b655-505c138634f7"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6a6ededf-a282-465a-a87f-056f1b075de2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""73eb9309-042c-485c-8423-e5d526f95322"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""308a1016-2615-4a3c-a49c-bfe9a4a2d94d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""6252dd55-fd88-4405-8c42-4b941fb8ccb5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f072efef-7d6a-4be4-8449-db4b24d6dacc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5c9a1f3-3269-48e4-8d83-cf2b3514d41e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""eb0c4ce2-be08-456b-bc7b-192c3435ba5c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b1fbc545-e17d-4ae2-9766-ac67bbd16fde"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bab614d4-4288-4c9c-9e26-4fc714ae4515"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""62648dbc-7f94-4250-b39b-22a6182bab82"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5f65891f-4a27-4850-ab39-2c520c8ddcf2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""922fa2ba-4d77-4924-b750-3cac536f268e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b7e2185-b903-460f-b821-a964f8cab156"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6a754cc-7aec-4476-92e5-9bf68128bb79"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a692c68-176d-4fa2-997d-5b12627e526e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;Controller"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerOG"",
            ""id"": ""6b4d3702-8243-4969-9b81-6c274a905979"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""87598b74-5125-40d9-8e41-0079128d7524"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""71802a86-b4cb-4b6b-b760-9a3d29944de1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""da190513-d4a5-43bc-9b3d-43534f3a2bb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""da56424b-f2f2-4ca9-b14f-c258f858c078"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""5b11ba55-09ff-4e5c-a9a6-1ce548667c99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""cab28fe1-5d9a-4248-9cef-6deaf229240e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5f5a8230-3d17-4cd3-809c-5ae95dcfa14f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7668e2af-3646-4f37-a263-09ce5d02db10"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ac13425b-4323-44b6-8694-d402c053c69e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ecdc81c3-2677-4abd-8c82-e00d562ed028"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ae109866-92cb-4f79-8c59-514654eb1803"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6711efe5-5b72-4768-8713-b0640b6564a0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7c170ecc-b572-464d-bdc8-564527045869"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c51bfd78-dc5a-45cd-b21c-b9bc35088b24"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c66b2100-f3d3-4c0a-8a8f-3bb1af11b79c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49ada38b-3423-483d-842b-3519217fb0b4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""488c5a03-e430-48c2-a013-4d98510181c3"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ad44395-76eb-4ecc-8eba-d07fbff3a70e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""737f6368-95f7-4664-8a6a-2e1c591d264e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""679a8fd8-de0a-4db6-8a25-a1d9c61355ed"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1d67c49-7da8-4ceb-b691-bf9bba19d25c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerOG1"",
            ""id"": ""2205b154-42b8-4d4e-a6d5-63d31244868b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5c9309d2-83b0-4610-bac3-2f5b95172d5d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c7ffe03c-1c75-46cf-9cc7-0ef8e91170ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""56242db6-514c-4e99-8efc-28112393ec25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""0c080e9e-8c2d-46fb-93fc-ec881267ddda"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""b3231c24-0ceb-46d1-beb6-1b008c23deb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""a68ed2cb-3137-44c6-aa3a-fa3d31b3ba30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d7cbcf36-17fd-4f30-8d6e-3e2673e506cc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6db75e4-d6ee-4b1e-aaa7-2ab5f63cec9b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ff393156-e509-4879-a143-18f0ff26ce0e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1ff1182c-6abe-49f4-968b-e5c4b5192c9d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c3ae2dfd-1bbc-4929-837f-a39d5d904e98"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf2d0fb5-8acb-40a8-a418-4265324d1634"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c73eaf0c-0e04-4c82-8212-b12f5b938d3b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c5297ad7-6bb2-4947-8fe7-9f90fe416cc1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1871f414-dba8-4440-b774-3fde4390aa65"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de774298-9242-44f0-9a7e-74b8e6fb7850"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88ed0beb-83bd-4ed3-b690-7aac03438613"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b40bccc2-961a-4bd4-bbd0-04f25692f8d5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""195efc03-087f-494a-b631-353eb76abd78"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""885282cd-2f19-4d8f-8414-7e0189653203"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9ba6736-8067-44d1-8878-fcadc0ee6119"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerOG2"",
            ""id"": ""f1463b6d-1db4-4265-be0b-e867ccb430ae"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8bacc7ac-827a-42d1-ba7d-07aa276dd4d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f0bf38ee-3513-41e1-8ca7-81a4183a5551"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""2a1988ab-ce1e-4f38-bc99-5091e120680c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""08b7ea17-67fe-43b0-ad18-bd0a1e011087"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""54a9c75a-ec74-4f25-afdb-5ae45fe1dcd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""945a6a34-8e43-40c3-81f3-07536dbc7607"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df197332-fee7-483b-a630-233b7d90d2ef"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1e42b38-2df0-4fa4-924e-ca82109c1a55"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f32fa334-2155-41b5-818e-b0b76825351f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b487a18a-f786-4a6d-b1b5-f788c9f45ce6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e23e25e4-cb7a-4b33-9f42-19d43b628296"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e58e24e4-7e64-4b49-af32-7c423321b36b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""be4b4efa-7103-4a18-8d07-6aa8e92bbbdf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""36ea4ee5-7dad-4c3f-8e29-5b730511721b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcf78b4b-80fa-4a83-856d-7769140dda54"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63da4aa4-bc22-4e81-ba58-114307ad843c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19122a11-aedb-45a4-b9ef-25f824f97f41"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""412a825c-f27a-401b-9480-b84ffc7942ac"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c71bf69-2dba-454b-b090-69cb65a7fd1b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d9350f8-1a23-4463-aab2-8e7a7194b843"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d7bb4c5-e990-406d-b640-463ee9064d1c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Action = m_Player.FindAction("Action", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Switch = m_Player.FindAction("Switch", throwIfNotFound: true);
        m_Player_Respawn = m_Player.FindAction("Respawn", throwIfNotFound: true);
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Movement = m_Player1.FindAction("Movement", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Action = m_Player1.FindAction("Action", throwIfNotFound: true);
        m_Player1_Switch = m_Player1.FindAction("Switch", throwIfNotFound: true);
        m_Player1_Respawn = m_Player1.FindAction("Respawn", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Movement = m_Player2.FindAction("Movement", throwIfNotFound: true);
        m_Player2_Jump = m_Player2.FindAction("Jump", throwIfNotFound: true);
        m_Player2_Action = m_Player2.FindAction("Action", throwIfNotFound: true);
        m_Player2_Aim = m_Player2.FindAction("Aim", throwIfNotFound: true);
        // Player3
        m_Player3 = asset.FindActionMap("Player3", throwIfNotFound: true);
        m_Player3_Movement = m_Player3.FindAction("Movement", throwIfNotFound: true);
        m_Player3_Jump = m_Player3.FindAction("Jump", throwIfNotFound: true);
        m_Player3_Action = m_Player3.FindAction("Action", throwIfNotFound: true);
        m_Player3_Aim = m_Player3.FindAction("Aim", throwIfNotFound: true);
        // PlayerOG
        m_PlayerOG = asset.FindActionMap("PlayerOG", throwIfNotFound: true);
        m_PlayerOG_Movement = m_PlayerOG.FindAction("Movement", throwIfNotFound: true);
        m_PlayerOG_Jump = m_PlayerOG.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOG_Action = m_PlayerOG.FindAction("Action", throwIfNotFound: true);
        m_PlayerOG_Aim = m_PlayerOG.FindAction("Aim", throwIfNotFound: true);
        m_PlayerOG_Switch = m_PlayerOG.FindAction("Switch", throwIfNotFound: true);
        m_PlayerOG_Respawn = m_PlayerOG.FindAction("Respawn", throwIfNotFound: true);
        // PlayerOG1
        m_PlayerOG1 = asset.FindActionMap("PlayerOG1", throwIfNotFound: true);
        m_PlayerOG1_Movement = m_PlayerOG1.FindAction("Movement", throwIfNotFound: true);
        m_PlayerOG1_Jump = m_PlayerOG1.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOG1_Action = m_PlayerOG1.FindAction("Action", throwIfNotFound: true);
        m_PlayerOG1_Aim = m_PlayerOG1.FindAction("Aim", throwIfNotFound: true);
        m_PlayerOG1_Switch = m_PlayerOG1.FindAction("Switch", throwIfNotFound: true);
        m_PlayerOG1_Respawn = m_PlayerOG1.FindAction("Respawn", throwIfNotFound: true);
        // PlayerOG2
        m_PlayerOG2 = asset.FindActionMap("PlayerOG2", throwIfNotFound: true);
        m_PlayerOG2_Movement = m_PlayerOG2.FindAction("Movement", throwIfNotFound: true);
        m_PlayerOG2_Jump = m_PlayerOG2.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOG2_Action = m_PlayerOG2.FindAction("Action", throwIfNotFound: true);
        m_PlayerOG2_Aim = m_PlayerOG2.FindAction("Aim", throwIfNotFound: true);
        m_PlayerOG2_Switch = m_PlayerOG2.FindAction("Switch", throwIfNotFound: true);
        m_PlayerOG2_Respawn = m_PlayerOG2.FindAction("Respawn", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Action;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Switch;
    private readonly InputAction m_Player_Respawn;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Action => m_Wrapper.m_Player_Action;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Switch => m_Wrapper.m_Player_Switch;
        public InputAction @Respawn => m_Wrapper.m_Player_Respawn;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Switch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitch;
                @Respawn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRespawn;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Movement;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Action;
    private readonly InputAction m_Player1_Switch;
    private readonly InputAction m_Player1_Respawn;
    public struct Player1Actions
    {
        private @InputActions m_Wrapper;
        public Player1Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player1_Movement;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Action => m_Wrapper.m_Player1_Action;
        public InputAction @Switch => m_Wrapper.m_Player1_Switch;
        public InputAction @Respawn => m_Wrapper.m_Player1_Respawn;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAction;
                @Switch.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSwitch;
                @Respawn.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRespawn;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Movement;
    private readonly InputAction m_Player2_Jump;
    private readonly InputAction m_Player2_Action;
    private readonly InputAction m_Player2_Aim;
    public struct Player2Actions
    {
        private @InputActions m_Wrapper;
        public Player2Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player2_Movement;
        public InputAction @Jump => m_Wrapper.m_Player2_Jump;
        public InputAction @Action => m_Wrapper.m_Player2_Action;
        public InputAction @Aim => m_Wrapper.m_Player2_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAction;
                @Aim.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);

    // Player3
    private readonly InputActionMap m_Player3;
    private IPlayer3Actions m_Player3ActionsCallbackInterface;
    private readonly InputAction m_Player3_Movement;
    private readonly InputAction m_Player3_Jump;
    private readonly InputAction m_Player3_Action;
    private readonly InputAction m_Player3_Aim;
    public struct Player3Actions
    {
        private @InputActions m_Wrapper;
        public Player3Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player3_Movement;
        public InputAction @Jump => m_Wrapper.m_Player3_Jump;
        public InputAction @Action => m_Wrapper.m_Player3_Action;
        public InputAction @Aim => m_Wrapper.m_Player3_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Player3; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player3Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer3Actions instance)
        {
            if (m_Wrapper.m_Player3ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player3ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player3ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player3ActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_Player3ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player3ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player3ActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_Player3ActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_Player3ActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_Player3ActionsCallbackInterface.OnAction;
                @Aim.started -= m_Wrapper.m_Player3ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_Player3ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_Player3ActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_Player3ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public Player3Actions @Player3 => new Player3Actions(this);

    // PlayerOG
    private readonly InputActionMap m_PlayerOG;
    private IPlayerOGActions m_PlayerOGActionsCallbackInterface;
    private readonly InputAction m_PlayerOG_Movement;
    private readonly InputAction m_PlayerOG_Jump;
    private readonly InputAction m_PlayerOG_Action;
    private readonly InputAction m_PlayerOG_Aim;
    private readonly InputAction m_PlayerOG_Switch;
    private readonly InputAction m_PlayerOG_Respawn;
    public struct PlayerOGActions
    {
        private @InputActions m_Wrapper;
        public PlayerOGActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerOG_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerOG_Jump;
        public InputAction @Action => m_Wrapper.m_PlayerOG_Action;
        public InputAction @Aim => m_Wrapper.m_PlayerOG_Aim;
        public InputAction @Switch => m_Wrapper.m_PlayerOG_Switch;
        public InputAction @Respawn => m_Wrapper.m_PlayerOG_Respawn;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOG; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOGActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOGActions instance)
        {
            if (m_Wrapper.m_PlayerOGActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnAction;
                @Aim.started -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnAim;
                @Switch.started -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnSwitch;
                @Respawn.started -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_PlayerOGActionsCallbackInterface.OnRespawn;
            }
            m_Wrapper.m_PlayerOGActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public PlayerOGActions @PlayerOG => new PlayerOGActions(this);

    // PlayerOG1
    private readonly InputActionMap m_PlayerOG1;
    private IPlayerOG1Actions m_PlayerOG1ActionsCallbackInterface;
    private readonly InputAction m_PlayerOG1_Movement;
    private readonly InputAction m_PlayerOG1_Jump;
    private readonly InputAction m_PlayerOG1_Action;
    private readonly InputAction m_PlayerOG1_Aim;
    private readonly InputAction m_PlayerOG1_Switch;
    private readonly InputAction m_PlayerOG1_Respawn;
    public struct PlayerOG1Actions
    {
        private @InputActions m_Wrapper;
        public PlayerOG1Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerOG1_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerOG1_Jump;
        public InputAction @Action => m_Wrapper.m_PlayerOG1_Action;
        public InputAction @Aim => m_Wrapper.m_PlayerOG1_Aim;
        public InputAction @Switch => m_Wrapper.m_PlayerOG1_Switch;
        public InputAction @Respawn => m_Wrapper.m_PlayerOG1_Respawn;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOG1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOG1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOG1Actions instance)
        {
            if (m_Wrapper.m_PlayerOG1ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnAction;
                @Aim.started -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnAim;
                @Switch.started -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnSwitch;
                @Respawn.started -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_PlayerOG1ActionsCallbackInterface.OnRespawn;
            }
            m_Wrapper.m_PlayerOG1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public PlayerOG1Actions @PlayerOG1 => new PlayerOG1Actions(this);

    // PlayerOG2
    private readonly InputActionMap m_PlayerOG2;
    private IPlayerOG2Actions m_PlayerOG2ActionsCallbackInterface;
    private readonly InputAction m_PlayerOG2_Movement;
    private readonly InputAction m_PlayerOG2_Jump;
    private readonly InputAction m_PlayerOG2_Action;
    private readonly InputAction m_PlayerOG2_Aim;
    private readonly InputAction m_PlayerOG2_Switch;
    private readonly InputAction m_PlayerOG2_Respawn;
    public struct PlayerOG2Actions
    {
        private @InputActions m_Wrapper;
        public PlayerOG2Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerOG2_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerOG2_Jump;
        public InputAction @Action => m_Wrapper.m_PlayerOG2_Action;
        public InputAction @Aim => m_Wrapper.m_PlayerOG2_Aim;
        public InputAction @Switch => m_Wrapper.m_PlayerOG2_Switch;
        public InputAction @Respawn => m_Wrapper.m_PlayerOG2_Respawn;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOG2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOG2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOG2Actions instance)
        {
            if (m_Wrapper.m_PlayerOG2ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnJump;
                @Action.started -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnAction;
                @Aim.started -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnAim;
                @Switch.started -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnSwitch;
                @Respawn.started -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_PlayerOG2ActionsCallbackInterface.OnRespawn;
            }
            m_Wrapper.m_PlayerOG2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public PlayerOG2Actions @PlayerOG2 => new PlayerOG2Actions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
    public interface IPlayer1Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IPlayer3Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IPlayerOGActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
    public interface IPlayerOG1Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
    public interface IPlayerOG2Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
}
