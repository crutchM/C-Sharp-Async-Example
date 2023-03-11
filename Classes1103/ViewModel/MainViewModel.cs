using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
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
    private HttpClient _http = new();

    public string FieldData
    {
        get => _fieldData;
        set => SetField(ref _fieldData, value);
    }

    public ICommand ButtonCommand =>
        new CommandDelegate(_ =>
        {
            // _ = Task.Run(async () =>
            // {
            //     FieldData = string.Join('\n', await _service.FindAllAsync());
            //     // int id = Random.Shared.Next(10000);
            //     // string uri = $"https://www.thisdickpicdoesnotexist.com/stylegan2_fakes_small/{id}.jpg";
            //     // var image = await _http.GetStreamAsync(uri);
            //     //
            //     // string filename = $"{Guid.NewGuid()}.jpg";
            //     // await using var fs = File.Create(filename);
            //     // await image.CopyToAsync(fs);
            //     // FieldData = "OK";
            //     // Process.Start(new ProcessStartInfo()
            //     // {
            //     //     FileName = fs.Name,
            //     //     UseShellExecute = true,
            //     // });
            // });
            Task.Run(async () =>
            {
                try
                {
                    FieldData = "Пожалуйста, подождите...";
                    FieldData = string.Join('\n', await _service.FindAllAsync());
                }
                catch (Exception e)
                {
                    FieldData = $"Пиздец! {e.Message}";
                }
            });
        });
}