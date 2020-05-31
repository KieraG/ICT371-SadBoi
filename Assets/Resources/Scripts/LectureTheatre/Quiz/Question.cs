[System.Serializable]
public class Question
{
    //The text of the question
    public string text;
    //Will give a multi choice if this flag is set to true, or a true or false choice if set to false
    public bool isTrue;
    //The text answer to the multichoice question
    public bool isMultichoice; 
    //If a true or false question, this is the answer to the text

    public string multiChoiceAnswer;
    //Options to the multichoice question that are not correct
    public string[] multiChoiceOptions;

}
