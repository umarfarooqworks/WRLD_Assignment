using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Testing : MonoBehaviour
{
    public string APIKey;

    [SerializeField]
    public PIOModels[] Models;
    public PIOModelCollection Model;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GetNFTData_Coroutine");
    }

    IEnumerator GetNFTData_Coroutine()
    {
        //id 11562
        //name RooftopCollection
        //APIKey ba6601cb9b259c9c23951150e319687f
        Debug.Log("APIKey: " + APIKey);
        //
        string uri = "https://poi.wrld3d.com/v1.1/poisets/11562/pois/?token=" + "b20134223a363df2d08f634a04f16bf46009fb5185d87a62ecc2d0f6520276c8c37428e4941a6c3b";
        UnityWebRequest request = new UnityWebRequest();
//        request.method = UnityWebRequest.kHttpVerbGET;

        using (request = UnityWebRequest.Get(uri))
        {
            request.SetRequestHeader("apikey", "ba6601cb9b259c9c23951150e319687f");
            //request.SetRequestHeader("name", "RooftopCollection");

            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string str = request.downloadHandler.text;
                str.TrimStart('[');
                str.TrimEnd(']');
                Debug.Log(str);
                Debug.Log("RequestSuccesful");
                Debug.Log(request.downloadHandler.text);
                //                Model.Add(new PIOModels());
                //
                Models = JsonHelper.FromJson<PIOModels>(request.downloadHandler.text);
                
                //AllNFTs.Add(new RootNFT());
                //AllNFTs[0] = JsonUtility.FromJson<RootNFT>(request.downloadHandler.text);
                //Debug.Log(request.downloadHandler.text);
                //CarClubNfts = AllNFTs[0].nfts_metadata.Where(x => (x.data.symbol.Equals("NCC")) && (!string.IsNullOrEmpty(x.data.uri))).ToList<NftsMetadata>();
                //foreach (NftsMetadata x in CarClubNfts)
                //{
                //    count++;
                //    Debug.Log("count :" + count);
                //    //                    GetTrait(CarClubNfts[0].data.uri);
                //    GetTrait(x.data.uri);
                //    //                    yield return new WaitUntil(ReturnedInformation); 
                //}

                //if (CarClubNfts.Count == 0)
                //{
                //    Debug.Log("Available NFT Count = " + CarClubNfts.Count);
                //    UIManager.Instance.OnDateFetchComplete();
                //}
            }
        }
    }
}

