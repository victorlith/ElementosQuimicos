using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElementosQuimicos.Models;
using System.Text.Json;
using System.IO;
using System.Reflection;


namespace ElementosQuimicos.ModelViews
{
    public partial class ElementoQuimicoViewModel : ObservableObject
    {        
        [ObservableProperty]
        private int simboloEntry;

        [ObservableProperty]
        private string corClassificação;

        [ObservableProperty]
        private ElementoQuimico elementt;

        public ElementoQuimicoViewModel()
        {
            if (string.IsNullOrEmpty(CorClassificação))
            {
                CorClassificação = "#F355B6";
            }
        }


        [RelayCommand]
        public async Task CarregarElementos()
        {
            string pathFile = @"elementos_quimicos.json";
            string jsonString;

            try
            {
                using (Stream stream = await FileSystem.OpenAppPackageFileAsync(pathFile))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        jsonString = await reader.ReadToEndAsync();

                        List<ElementoQuimico> elementos = JsonSerializer.Deserialize<List<ElementoQuimico>>(jsonString);

                        Elementt = elementos.Find(e => e.Numero_Atomico == SimboloEntry);


                        VerificarClassificacao();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }

            //using (FileStream stream = File.OpenRead(pathFile))
            //{
            //    Elementt = new ElementoQuimico(); 
            //    List<ElementoQuimico> elementos = JsonSerializer.Deserialize<List<ElementoQuimico>>(stream);

            //    Elementt = elementos.Find(e => e.Numero_Atomico == SimboloEntry);

            //    //if (Elementt != null)
            //    //{
            //    //    NomeElemento = Elementt.Nome_Elemento;
            //    //    ElementosQuimicos.Clear();
            //    //    ElementosQuimicos.Add(Elementt);         
            //    //}
            //}
        }


        private string VerificarClassificacao()
        {

            string classificacao = Elementt.Classificacao;

            switch (classificacao)
            {
                case "Metal alcalino":
                    CorClassificação = "#DA1617";
                    break;

                case "Metal alcalino-terroso":
                    CorClassificação = "#DBA440";
                    break;

                case "Lantanídeo":
                    CorClassificação = "#0060EB";
                    break;

                case "Actinídeo":
                    CorClassificação = "#3F98F2";
                    break;

                case "Metal de transição":
                    CorClassificação = "#1FC849";
                    break;

                case "Metal representativo":
                    CorClassificação = "#B75BEA";
                    break;

                case "Metalóide":
                    CorClassificação = "#FDCF08";
                    break;

                case "Não metal":
                    CorClassificação = "#F37101";
                    break;

                case "Gás nobre":
                    CorClassificação = "#F355B6";
                    break;

                case "Desconhecido":
                    CorClassificação = "#918383";
                    break;
            }

            return CorClassificação;
        }

    }
}
