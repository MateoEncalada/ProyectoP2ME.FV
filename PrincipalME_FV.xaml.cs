using Microsoft.VisualBasic;
using ProyectoP2ME.FV.Models;
using System.Collections.ObjectModel;

namespace ProyectoP2ME.FV;

public partial class PrincipalME_FV : ContentPage
{ 
 List<InformacionME_FV> informationList = new List<InformacionME_FV>();
ObservableCollection<InformacionME_FV> displayedInformationList = new ObservableCollection<InformacionME_FV>();

public PrincipalME_FV()
{
    InitializeComponent();
    infoListView.ItemsSource = displayedInformationList;
}

    //private void AddToTable(object sender, EventArgs e)
    //{
    //    InformacionME_FV information = new InformacionME_FV
    //    {
    //        Semestre = semesterEntry.Text,
    //        Materia = subjectEntry.Text,
    //        NombreProfesor = professorEntry.Text,
    //        Calificacion = ratingEntry.Text,
    //        Descripcion = descriptionEntry.Text,
    //        Cualidad = qualityEntry.Text,
    //        Horario = scheduleEntry.Text
    //    };

    //    informationList.Add(information);
    //    displayedInformationList.Add(information);

    //    ClearEntries();
    //}
    public async void AddToTable(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        await App.InfoRepo.AddNewInfo(semesterEntry.Text, subjectEntry.Text, professorEntry.Text, ratingEntry.Text, descriptionEntry.Text, qualityEntry.Text, scheduleEntry.Text);
        statusMessage.Text = App.InfoRepo.StatusMessage;
    }
    public async void MostrarLista(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<InformacionME_FV> info = await App.InfoRepo.GetAllPeople();
        infoListView.ItemsSource = info;
    }

    private void Search(object sender, EventArgs e)
{
    string searchKeyword = searchEntry.Text.ToLower();

    displayedInformationList.Clear();

    foreach (var information in informationList)
    {
        if (information.Materia.ToLower().Contains(searchKeyword))
        {
            displayedInformationList.Add(information);
        }
    }
}

private async void DeleteItem(object sender, EventArgs e)
{
    if (sender is Button button && button.CommandParameter is InformacionME_FV information)
    {
        await DeleteInformation(information);
    }
}

private async void ModifyItem(object sender, EventArgs e)
{
    if (sender is Button button && button.CommandParameter is InformacionME_FV information)
    {
        await ModifyInformation(information);
    }
}

private async Task DeleteInformation(InformacionME_FV information)
{
    await Task.Delay(100); // Simulating an asynchronous operation
    informationList.Remove(information);
    displayedInformationList.Remove(information);
}

private async Task ModifyInformation(InformacionME_FV information)
{
    await Task.Delay(100); // Simulating an asynchronous operation
                           // Set the information values to the entry fields
    semesterEntry.Text = information.Semestre;
    subjectEntry.Text = information.Materia;
    professorEntry.Text = information.NombreProfesor;
    ratingEntry.Text = information.Calificacion;
    descriptionEntry.Text = information.Descripcion;
    qualityEntry.Text = information.Cualidad;
    scheduleEntry.Text = information.Horario;

    // Remove the information from the list temporarily for modification
    informationList.Remove(information);
    displayedInformationList.Remove(information);
}

private void ClearEntries()
{
    semesterEntry.Text = string.Empty;
    subjectEntry.Text = string.Empty;
    professorEntry.Text = string.Empty;
    ratingEntry.Text = string.Empty;
    descriptionEntry.Text = string.Empty;
    qualityEntry.Text = string.Empty;
    scheduleEntry.Text = string.Empty;
}

    
}