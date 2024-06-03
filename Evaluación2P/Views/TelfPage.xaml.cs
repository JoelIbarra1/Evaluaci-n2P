using Evaluación2P.Models;

namespace Evaluación2P.Views;

public partial class TelfPage : ContentPage
{
	public TelfPage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(appDataPath, randomFileName));
    }
    
    private async void JISaveButton_Clicked(object sender, EventArgs e, Telefono telefono)
    {
        if (BindingContext is Models.Telefono telf)
        {
            
            File.WriteAllText(telf.Filename, JITextEditor1.Text);
            File.WriteAllText(telf.Numerot, JITextEditor1.Text);
            File.WriteAllText(telf.Operador, JITextEditor2.Text);
            File.WriteAllText(telf.valor, JITextEditor3.Text);
        }
            
            


        await Shell.Current.GoToAsync("..");
    }
    private void LoadNote(string fileName)
    {
        Models.Telefono noteModel = new Models.Telefono();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Numerot = File.ReadAllText(fileName);
            noteModel.Operador = File.ReadAllText(fileName);
            noteModel.valor = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
    public string ItemId
    {
        set { LoadNote(value); }
    }
}