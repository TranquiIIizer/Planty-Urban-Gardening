using System;
using Plants;
using UnityEngine;

namespace Grid
{
    public class GridPlantSpriteUpdater : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private int _daysToFullyGrown;
        private bool _occupied;
        private int _remainingDays;
        private float _daysToNextGrowPhase;
        private int _phaseIndex;
        private int _spriteChangePeriod;
        private Sprite[] _plantSprites;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
            _occupied = false;
            InitializePlantSprite(GetComponentInParent<Plant>().plantData);
        }

        public void InitializePlantSprite(PlantScriptableObject  plant)
        {
            
            _occupied = true;
            _phaseIndex = 0;
            
            _plantSprites = plant.GetPlantSprites();
            
            int spritesCount = _plantSprites.Length;
            _spriteRenderer.sprite = _plantSprites[0];
            _spriteRenderer.enabled = true;
            
            _daysToFullyGrown = plant.GetDaysToFullyGrownInt();
            _remainingDays = _daysToFullyGrown;
            _spriteChangePeriod = _daysToFullyGrown / spritesCount;
        }

        public void DaysToFullyGrownUpdate()
        {
            if (_occupied)
            {
                _remainingDays--;
                _daysToNextGrowPhase++;
                
                if (_daysToNextGrowPhase >= _spriteChangePeriod)
                {
                    _phaseIndex++;
                    try
                    {
                        _spriteRenderer.sprite = _plantSprites[_phaseIndex];
                    }
                    catch (IndexOutOfRangeException){ Debug.Log(_remainingDays);}
                    
                    _daysToNextGrowPhase = 0;
                }
                
                if (_remainingDays <= 0)
                {
                    _spriteRenderer.sprite = _plantSprites[^1];
                    GameTimeManager.TimeTickEvent -= DaysToFullyGrownUpdate;
                }
            }
        }
    }
}
