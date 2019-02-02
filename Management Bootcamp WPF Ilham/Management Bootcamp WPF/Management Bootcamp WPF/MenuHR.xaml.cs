using Microservice.BussinessLogic.Services;
using Microservice.BussinessLogic.Services.Master;
using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Management_Bootcamp_WPF
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MenuHR : Window
    {
        IDepartmentService _departmentService = new DepartmentService();
        DepartmentParam departmentParam = new DepartmentParam();

        IPlacementService _placementService = new PlacementService();
        PlacementParam placementParam = new PlacementParam();
        
        IBatchService _batchService = new BatchService();
        BatchParam batchParam = new BatchParam();

        IRoomService _roomService = new RoomService();
        RoomParam roomParam = new RoomParam();       
        //string id;
        //string name;
        public MenuHR()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            textBoxName.Text = "";
            textBlockId.Text = "";
            dataGridDepartment.ItemsSource = _departmentService.Get();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridDepartment.ItemsSource = _departmentService.Get();         //Data grid department
            dataGridBatch.ItemsSource = _batchService.Get();                    // Data grid Batch
            dataGridPlacement.ItemsSource = _placementService.Get();
            dataGridRoom.ItemsSource = _roomService.Get();

        }

        // MENU DEPARTMENT
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            departmentParam.Name = textBoxName.Text;
            if (string.IsNullOrEmpty(textBoxName.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxName.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {                
                _departmentService.Insert(departmentParam);
                LoadGrid();
            }                        
        }
        
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                departmentParam.Name = textBoxName.Text;
                if (string.IsNullOrEmpty(textBoxName.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxName.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _departmentService.Update(Convert.ToInt16(textBlockId.Text), departmentParam);
                    LoadGrid();
                }
            }            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {           
            object item = dataGridDepartment.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _departmentService.Delete(Convert.ToInt16(textBlockId.Text));
                LoadGrid();
            }            
        }

        private void dataGridDepartment_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridDepartment.SelectedItem;
            if ( dataGridDepartment.SelectedIndex < 0)
            {
                textBlockId.Text = "";
                textBoxName.Text = "";
            } else
            {
                textBlockId.Text = (dataGridDepartment.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxName.Text = (dataGridDepartment.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }            
        }

        private void textBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. ]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridDepartment.ItemsSource = _departmentService.Search(textBoxSearch.Text, comboBoxSearch.Text);
                }
            }            
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridDepartment.ItemsSource = _departmentService.Search(textBoxSearch.Text, comboBoxSearch.Text);
                }
            }
        }

        //====================================================================================================================
        //MANAGE BATCH
        private void LoadGridBatch()
        {
            textBlockIdBatch.Text = "";
            textBoxNameBatch.Text = "";
            dataGridBatch.ItemsSource = _batchService.Get();

        }
        private void buttonInsertBatch_Click(object sender, RoutedEventArgs e)
        {
            batchParam.Name = textBoxNameBatch.Text;
            if (string.IsNullOrEmpty(textBoxNameBatch.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameBatch.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                _batchService.Insert(batchParam);
                LoadGridBatch();
            }
        }
        private void textBoxNameBatch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z. 0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonUpdateBatch_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridBatch.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                batchParam.Name = textBoxNameBatch.Text;
                if (string.IsNullOrEmpty(textBoxNameBatch.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameBatch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _batchService.Update(Convert.ToInt16(textBlockIdBatch.Text), batchParam);
                    LoadGridBatch();
                }
            }
        }

        private void dataGridBatch_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridBatch.SelectedItem;
            if (dataGridBatch.SelectedIndex < 0)
            {
                textBlockIdBatch.Text = "";
                textBoxNameBatch.Text = "";
            }
            else
            {
                textBlockIdBatch.Text = (dataGridBatch.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameBatch.Text = (dataGridBatch.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }
        }

        private void buttonDeleteBatch_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridBatch.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _batchService.Delete(Convert.ToInt16(textBlockIdBatch.Text));
                LoadGridBatch();
            }
        }

        private void buttonSearchBatch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchBatch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridBatch.ItemsSource = _batchService.Search(textBoxSearchBatch.Text, comboBoxSearchBatch.Text);
                }
            }
        }

        private void textBoxSearchBatch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchBatch.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchBatch.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridBatch.ItemsSource = _batchService.Search(textBoxSearchBatch.Text, comboBoxSearchBatch.Text);
                }
            }
        }

        //====================================================================================================================
        //MANAGE PLACEMENT
        private void LoadGridPlacement()
        {
            textBlockIdPlacement.Text = "";
            textBoxNamePlacement.Text = "";
            textBoxAddressPlacement.Text = "";
            textBoxRtPlacement.Text = "";
            textBoxRwPlacement.Text = "";
            textBoxKelurahanPlacement.Text = "";
            textBoxKecamatanPlacement.Text = "";
            textBoxKabupatenPlacement.Text = "";
            textBoxPhonePlacement.Text = "";
            dataGridPlacement.ItemsSource = _placementService.Get();

        }
        private void buttonSearchPlacement_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchPlacement.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridPlacement.ItemsSource = _placementService.Search(textBoxSearchPlacement.Text, comboBoxSearchPlacement.Text);
                }
            }
        }
        private void textBoxSearchPlacement_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (string.IsNullOrEmpty(comboBoxSearchPlacement.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchPlacement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridPlacement.ItemsSource = _placementService.Search(textBoxSearchPlacement.Text, comboBoxSearchPlacement.Text);
                }
            }
        }

        private void buttonInsertPlacement_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxNamePlacement.Text) == true)
            {
                MessageBox.Show("Please insert name department!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNamePlacement.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                placementParam.Name = textBoxNamePlacement.Text;
                placementParam.Address = textBoxAddressPlacement.Text;
                placementParam.RT = Convert.ToInt16(textBoxRtPlacement.Text);
                placementParam.RW = Convert.ToInt16(textBoxRwPlacement.Text);
                placementParam.Kelurahan = textBoxKelurahanPlacement.Text;
                placementParam.Kecamatan = textBoxKecamatanPlacement.Text;
                placementParam.Kabupaten = textBoxKabupatenPlacement.Text;
                placementParam.Phone = textBoxPhonePlacement.Text;

                _placementService.Insert(placementParam);
                LoadGridPlacement();
            }
        }

        private void textBoxNamePlacement_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z., 0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void buttonUpdatePlacement_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridPlacement.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {
                placementParam.Name = textBoxNamePlacement.Text;
                placementParam.Address = textBoxAddressPlacement.Text;
                placementParam.RT = Convert.ToInt16(textBoxRtPlacement.Text);
                placementParam.RW = Convert.ToInt16(textBoxRwPlacement.Text);
                placementParam.Kelurahan = textBoxKelurahanPlacement.Text;
                placementParam.Kecamatan = textBoxKecamatanPlacement.Text;
                placementParam.Kabupaten = textBoxKabupatenPlacement.Text;
                placementParam.Phone = textBoxPhonePlacement.Text;
                if (string.IsNullOrEmpty(textBoxNamePlacement.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNamePlacement.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    _placementService.Update(Convert.ToInt16(textBlockIdPlacement.Text), placementParam);
                    LoadGridPlacement();
                }
            }
        }

        private void buttonDeletePlacement_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridPlacement.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _placementService.Delete(Convert.ToInt16(textBlockIdPlacement.Text));
                LoadGridPlacement();
            }
        }

        private void dataGridPlacement_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridPlacement.SelectedItem;
            if (dataGridPlacement.SelectedIndex < 0)
            {
                textBlockIdPlacement.Text = "";
                textBoxNamePlacement.Text = "";
                textBoxAddressPlacement.Text = "";
                textBoxRtPlacement.Text = "";
                textBoxRwPlacement.Text = "";
                textBoxKelurahanPlacement.Text = "";
                textBoxKecamatanPlacement.Text = "";
                textBoxKabupatenPlacement.Text = "";
                textBoxPhonePlacement.Text = "";
            }
            else
            {
                textBlockIdPlacement.Text = (dataGridPlacement.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNamePlacement.Text = (dataGridPlacement.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxAddressPlacement.Text = (dataGridPlacement.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxRtPlacement.Text= (dataGridPlacement.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                textBoxRwPlacement.Text = (dataGridPlacement.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                textBoxKelurahanPlacement.Text = (dataGridPlacement.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                textBoxKecamatanPlacement.Text = (dataGridPlacement.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                textBoxKabupatenPlacement.Text = (dataGridPlacement.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                textBoxPhonePlacement.Text = (dataGridPlacement.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
            }

        }

        private void textBoxPhonePlacement_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[+0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }


        //=====================================================================================================================================
        //MANAGE ROOM

        private void LoadGridRoom()
        {
            textBlockIdRoom.Text = "";
            textBoxNameRoom.Text = "";
            textBoxCapacityRoom.Text = "";
            textBoxLocationRoom.Text = "";
            dataGridRoom.ItemsSource = _roomService.Get();
        }
        private void buttonInsertRoom_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBoxNameRoom.Text) == true)
            {
                MessageBox.Show("Please insert name room!");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNameRoom.Text) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else if (string.IsNullOrEmpty(textBoxCapacityRoom.Text) == true)
            {
                MessageBox.Show("Please insert capacity room!");
            }
            else if (string.IsNullOrEmpty(textBoxLocationRoom.Text) == true)
            {
                MessageBox.Show("Please insert Location room!");
            }
            else
            {
                roomParam.Name = textBoxNameRoom.Text;
                roomParam.Capacity = Convert.ToInt32(textBoxCapacityRoom.Text);
                roomParam.Location = textBoxLocationRoom.Text;

                _roomService.Insert(roomParam);
                LoadGridRoom();
            }
        }

        private void buttonUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridRoom.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to edit!");
            }
            else
            {

                if (string.IsNullOrEmpty(textBoxNameRoom.Text) == true)
                {
                    MessageBox.Show("Please insert name department!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxNameRoom.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else if (string.IsNullOrEmpty(textBoxCapacityRoom.Text) == true)
                {
                    MessageBox.Show("Please insert capacity room!");
                }
                else if (string.IsNullOrEmpty(textBoxLocationRoom.Text) == true)
                {
                    MessageBox.Show("Please insert Location room!");
                }
                else
                {
                    roomParam.Name = textBoxNameRoom.Text;
                    roomParam.Capacity = Convert.ToInt32(textBoxCapacityRoom.Text);
                    roomParam.Location = textBoxLocationRoom.Text;

                    _roomService.Update(Convert.ToInt16(textBlockIdRoom.Text), roomParam);
                    LoadGridRoom();
                }
            }
        }

        private void buttonDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridRoom.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Please choice data want to delete!");
            }
            else
            {
                _roomService.Delete(Convert.ToInt16(textBlockIdRoom.Text));
                LoadGridRoom();
            }
        }

        private void buttonSearchRoom_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxSearchRoom.Text) == true)
            {
                MessageBox.Show("Please choice category search!");
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxSearchRoom.Text) == true)
                {
                    MessageBox.Show("Please insert keywoard search!");
                }
                else if (string.IsNullOrWhiteSpace(textBoxSearchRoom.Text) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    dataGridRoom.ItemsSource = _roomService.Search(textBoxSearchRoom.Text, comboBoxSearchRoom.Text);
                }
            }
        }

        private void dataGridRoom_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = dataGridRoom.SelectedItem;
            if (dataGridRoom.SelectedIndex < 0)
            {
                textBlockIdRoom.Text = "";
                textBoxNameRoom.Text = "";
                textBoxCapacityRoom.Text = "";
                textBoxLocationRoom.Text = "";
            }
            else
            {
                textBlockIdRoom.Text = (dataGridRoom.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                textBoxNameRoom.Text = (dataGridRoom.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                textBoxCapacityRoom.Text = (dataGridRoom.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                textBoxLocationRoom.Text = (dataGridRoom.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            }
        }
    }
}

