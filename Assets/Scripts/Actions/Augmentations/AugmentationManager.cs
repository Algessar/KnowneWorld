using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentationManager : MonoBehaviour
{
    public Dictionary<string, SOEffectWord> effectWordDictionary = new Dictionary<string, SOEffectWord>();

    [SerializeField] private SOAugmentations[] _augmentations;
}
