using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResponceHandler : MonoBehaviour
{
    [SerializeField] private RectTransform respBox;
    [SerializeField] private RectTransform ButtonTemplate;
    [SerializeField] private RectTransform ResponseContainer;
    private DialogUA dialogUA;
    private ResponceEvent[] responceEvent;

    List<GameObject> tempButtons = new List<GameObject>();

    private void Start()
    {
        respBox.gameObject.SetActive(false);
        dialogUA = GetComponent<DialogUA>();
    }
    public void AddResponseEvents(ResponceEvent[] responceEvent)
    {
        this.responceEvent = responceEvent;
    }

    public void ShowResponses(Responce[] responces, int ii)
    {
        ButtonTemplate.gameObject.SetActive(false);
        for(int i =0; i< responces.Length;i++)
        {
            Responce responce = responces[i];
            int responseindex = i;
            GameObject responseButton = Instantiate(ButtonTemplate.gameObject, ResponseContainer);
            responseButton.gameObject.SetActive(true);
            if(ii== 1)
            {
                responseButton.GetComponent<TMP_Text>().text = RemoveTextAfterSymbol(responce.ResponseText, '%');
            }
            else
            {
                responseButton.GetComponent<TMP_Text>().text = RemoveTextBeforeSymbol(responce.ResponseText, '%');
            }
            //responseButton.GetComponent<TMP_Text>().text = responce.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(responce, responseindex));
            tempButtons.Add(responseButton);
            respBox.gameObject.SetActive(true);
        }
    }

    public string RemoveTextBeforeSymbol(string input, char symbol)
    {
        int index = input.IndexOf(symbol);
        if (index >= 0)
        {
            string result = input.Substring(index + 1);
            return result;
        }

        return input;
    }
    public string RemoveTextAfterSymbol(string input, char symbol)
    {
        int index = input.IndexOf(symbol);
        if (index >= 0)
        {
            string result = input.Substring(0, index);
            return result;
        }

        return input;
    }

    private void OnPickedResponse(Responce responce, int respIndex)
    {
        respBox.gameObject.SetActive(false);
        foreach (GameObject butt in tempButtons)
        {
            Destroy(butt);
        }
        tempButtons.Clear();
        responceEvent[respIndex].OnPickedResponse.Invoke();
        //if (responceEvent != null && respIndex <= responceEvent.Length)
        //{
        //    responceEvent[respIndex].OnPickedResponse?.Invoke();
        //}
        //responceEvent = null;
        if (responce.DialogOdject)
        {
            dialogUA.ShowDialog(responce.DialogOdject);
        }
        else
        {
            dialogUA.CloseBox();
        }
        

        
    }

}
