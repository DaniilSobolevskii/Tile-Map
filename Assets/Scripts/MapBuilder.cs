using System;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MapBuilder : MonoBehaviour
{
    /// <summary>
    /// Данный метод вызывается автоматически при клике на кнопки с изображениями тайлов.
    /// В качестве параметра передается префаб тайла, изображенный на кнопке.
    /// Вы можете использовать префаб tilePrefab внутри данного метода.
    /// </summary>
    ///
    private GameObject _object;
    [SerializeField] 
    private Map _map;


    public void StartPlacingTile(GameObject tilePrefab)
    {
       // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _object = Instantiate(tilePrefab);
        
      //  _object.transform.position = ray.direction;
    } 
    

    public void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hitInfo)&&_object != null)
        {

            var tileIndex = _map.GetIndex(hitInfo.point);
            var tilePosition = _map.GetTilePosition(tileIndex);
            _object.transform.localPosition = tilePosition;

            var IsAvailible = _map.IsSellIsAvalible(tileIndex);
            var _tile = _object.GetComponent<Tile>();
            _tile.SetColor(IsAvailible);
            
            if (Input.GetMouseButton(0)&& IsAvailible)
            {
                _map.SetTile(tileIndex, _tile);
                _tile.ResetColor();
                _object = null;      
            } 
            
             
        }
        
    }
}