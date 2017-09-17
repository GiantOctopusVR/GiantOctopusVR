using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
public class SpatialManager : MonoBehaviour {
    private List<GameObject> planes;
    private GameObject floorPlane;
    public TextMesh UIText;
    public GameObject cubePrefab;
    private void Start()
    {
        UIText.text = "Walk around and scan your playspace";
#if UNITY_EDITOR
        Invoke("CallMakePlanes", 2);
#else
        Invoke("CallMakePlanes", 10);
#endif
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += Instance_MakePlanesComplete;
    }

    private void Instance_MakePlanesComplete(object source, System.EventArgs args)
    {
        UIText.text = "";
        SpatialMappingManager.Instance.DrawVisualMeshes = false;
        planes = SurfaceMeshesToPlanes.Instance.GetActivePlanes(PlaneTypes.Floor);
        float minimumDistance = 100;
        foreach(GameObject plane in planes)
        {
            if((Vector3.Distance(Camera.main.transform.position, plane.transform.position) < minimumDistance))
            {
                minimumDistance = Vector3.Distance(Camera.main.transform.position, plane.transform.position);
                floorPlane = plane;
            }
        }
        instantiateCubeOnTablePlane(floorPlane);
    }
    private void CallMakePlanes()
    {
        SurfaceMeshesToPlanes.Instance.MakePlanes();
    }
    private void instantiateCubeOnTablePlane(GameObject plane)
    {
      GameObject tablePlane = Instantiate(cubePrefab, plane.transform.position, Quaternion.identity);
      //tablePlane.transform.localScale = table.transform.localScale;
        tablePlane.AddComponent<TableBehavior>();
    }
}
