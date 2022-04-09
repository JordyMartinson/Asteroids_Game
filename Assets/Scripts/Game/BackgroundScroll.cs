// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// public class BackgroundScroll : MonoBehaviour
// {
//     // public GameObject[] backgrounds;
//     public GameObject background;
//     private Camera mainCam;
//     private Vector2 screenBounds;

//     void Start() {
//         mainCam = gameObject.GetComponent<Camera>();
//         screenBounds = mainCam.ScreenToWorldPoint(
//             new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
//         // foreach(GameObject obj in backgrounds) {
//         //     loadChildObjects(obj);
//         // }
//         loadChildObjects(background);
//     }

//     public void loadChildObjects(GameObject obj) {
//         float objW = obj.GetComponent<SpriteRenderer>().bounds.size.x;

//         int childsNeededX = (int)Mathf.Ceil(screenBounds.x * 2 / objW);

//         GameObject cloneX = Instantiate(obj) as GameObject;

//         for(int i = 0; i <= childsNeededX; i++) {
//             GameObject c = Instantiate(cloneX) as GameObject;
//             c.transform.SetParent(obj.transform);
//             c.transform.position = 
//                 new Vector3(objW * i, obj.transform.position.y, obj.transform.position.z);
//             c.name = obj.name + "w" + i;
//         }
//         Destroy(cloneX);

//         float objH = obj.GetComponent<SpriteRenderer>().bounds.size.y;

//         int childsNeededY = (int)Mathf.Ceil(screenBounds.y * 2 / objH);

//         GameObject cloneY = Instantiate(obj) as GameObject;

//         for(int i = 0; i <= childsNeededY; i++) {
//             GameObject c = Instantiate(cloneY) as GameObject;
//             c.transform.SetParent(obj.transform);
//             c.transform.position = 
//                 new Vector3(obj.transform.position.x, objH * i, obj.transform.position.z);
//             c.name = obj.name + "h" + i;
//         }
//         Destroy(cloneY);
//         Destroy(obj.GetComponent<SpriteRenderer>());
//     }

// //     // public void repositionChildObjectsY(GameObject obj) {
// //     //     Transform[] children = obj.GetComponentsInChildren<Transform>();
// //     //     if(children.Length > 1) {
// //     //         GameObject firstChild = children[1].gameObject;
// //     //         GameObject lastChild = children[children.Length - 1].gameObject;
// //     //         float halfObjectHeight = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;
// //     //         if(transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectHeight) {
// //     //             firstChild.transform.SetAsLastSibling();
// //     //             firstChild.transform.position =
// //     //                 new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectHeight * 2, lastChild.transform.position.z);
// //     //         } else if(transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectHeight) {
// //     //             lastChild.transform.SetAsFirstSibling();
// //     //             lastChild.transform.position =
// //     //                 new Vector3(firstChild.transform.position.x, firstChild.transform.position.y - halfObjectHeight * 2, firstChild.transform.position.z);
// //     //         }
// //     //     }
// //     // }

//     public void repositionChildObjects(GameObject obj) {
//         Transform[] children = obj.GetComponentsInChildren<Transform>();
//         if(children.Length > 1) {
//             GameObject firstChild = children[1].gameObject;
//             GameObject lastChild = children[children.Length - 1].gameObject;
//             float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
//             float halfObjectHeight = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;

//             if(transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectHeight) {
//                 firstChild.transform.SetAsLastSibling();
//                 firstChild.transform.position =
//                     new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectHeight * 2, lastChild.transform.position.z);
//             } else if(transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectHeight) {
//                 lastChild.transform.SetAsFirstSibling();
//                 lastChild.transform.position =
//                     new Vector3(firstChild.transform.position.y, firstChild.transform.position.y - halfObjectHeight * 2, firstChild.transform.position.z);
//             }

//             if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth) {
//                 firstChild.transform.SetAsLastSibling();
//                 firstChild.transform.position =
//                     new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
//             } else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) {
//                 lastChild.transform.SetAsFirstSibling();
//                 lastChild.transform.position =
//                     new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
//             }
//         }
//     }

//     public void LateUpdate() {
//         // foreach(GameObject obj in backgrounds) {
//         //     repositionChildObjects(obj);
//         // }
//         repositionChildObjects(background);
//         // repositionChildObjectsX(background);
//     }
// }

// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class BackgroundScroll : MonoBehaviour
// // {
// //     public GameObject background;
// //     private Camera mainCam;
// //     private Vector2 screenBounds;

// //     public void Start() {
// //         mainCam = gameObject.GetComponent<Camera>();
// //         screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
// //         bounds(background);
// //     }

// //     public void bounds(GameObject obj) {
// //         float objW = obj.GetComponent<SpriteRenderer>().bounds.size.x;
// //         int childsNeeded = (int) Mathf.Ceil(screenBounds.x * 2 / objW);
// //         Debug.Log(childsNeeded);
// //     }
// // }
