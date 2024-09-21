using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Ejercicio_CRUD_Mvvm
{
    public partial class ProveedoresPage : ContentPage
    {
        public ProveedoresPage()
        {
            InitializeComponent();
            BindingContext = new ProveedorViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }

    public class ProveedorViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Proveedor> Proveedores { get; set; }
    private Proveedor _selectedProveedor;
    public Proveedor SelectedProveedor
    {
        get => _selectedProveedor;
        set
        {
            _selectedProveedor = value;
            OnPropertyChanged(nameof(SelectedProveedor));
        }
    }

    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }

    public ProveedorViewModel()
    {
        Proveedores = new ObservableCollection<Proveedor>();
        SaveCommand = new Command(async () => await SaveProveedor());
        DeleteCommand = new Command(async () => await DeleteProveedor());
    }

    private async Task SaveProveedor()
    {
        if (string.IsNullOrEmpty(SelectedProveedor.Nombre))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "El nombre no puede estar vacío", "OK");
            return;
        }
        // Guardar en la base de datos
    }

    private async Task DeleteProveedor()
    {
        // Eliminar de la base de datos
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
}