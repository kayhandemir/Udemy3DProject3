using UdemyProje3.Abstracts.Uis;
using UdemyProje3.Managers;

namespace UdemyProje3.UIs
{
    public class ReturnButton : MyButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.ReturnMenu();      
        }
    }
}

