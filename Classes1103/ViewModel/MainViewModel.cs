using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Classes1103.Extra;
using Classes1103.Model;
using Classes1103.Model.Data;
using Classes1103.Model.Services;

namespace Classes1103.ViewModel;

public class MainViewModel : ViewModel
{
    private IAsyncDataService<SampleInfo> _service = new LocalDataService();
    private string _fieldData;

    public string FieldData
    {
        get => _fieldData;
        set => SetField(ref _fieldData, value);
    }

    public ICommand ButtonCommand =>
        new CommandDelegate(parameter =>
        {
            _ = Task.Run(async () =>
            {
                FieldData = "Ща все будет";
                try
                {
                    FieldData = string.Join('\n', await _service.FindAllAsync());
                }
                catch (Exception e)
                {
                    FieldData = "Рикролл";
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                        UseShellExecute = true,
                    });
                }
            });
            // Task.Run(async () =>
            // {
            //     FieldData = string.Join('\n', await _service.FindAllAsync());
            // }).Wait();
        });
}