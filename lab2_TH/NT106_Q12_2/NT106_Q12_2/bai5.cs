using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace NT106_Q12_2
{
    public partial class bai5 : Form
    {
        public bai5()
        {
            InitializeComponent();
        }

        //"C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai5\\input5.txt"
        private string path = "C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai5\\input5.txt";
        private string out_path = "C:\\Users\\NAM\\Desktop\\NT106\\lab2_TH\\NT106_Q12_2\\NT106_Q12_2\\bai5\\output5.txt";
        private string trunggian = "./trunggian.json";
        private static readonly string[] SEATS = new[]
        {
            "A1","A2","A3","A4","A5",
            "B1","B2","B3","B4","B5",
            "C1","C2","C3","C4","C5"
        };
        public class RootDef { public List<MovieDef> Movies { get; set; } = new(); }
        public class MovieDef
        {
            public string Name { get; set; } = "";
            public int BasePrice { get; set; }
            public List<int> Rooms { get; set; } = new();
        }
        private Dictionary<string, object> BuildFreshState(RootDef defs)
        {
            var state = new Dictionary<string, object>();

            foreach (var mv in defs.Movies)
            {
                var movieObj = new Dictionary<string, object>();
                movieObj["cost"] = mv.BasePrice;

                var roomMap = new Dictionary<string, object>();
                foreach (var room in mv.Rooms)
                {
                    var seats = new Dictionary<string, int>();
                    foreach (var s in SEATS) seats[s] = 0;
                    roomMap[room.ToString()] = seats;
                }

                movieObj["room"] = roomMap;
                state[mv.Name] = movieObj;
            }

            return state;
        }

        private void bai5_Load(object sender, EventArgs e)
        {
            btn_a1.Enabled = false;
            btn_a2.Enabled = false;
            btn_a3.Enabled = false;
            btn_a4.Enabled = false;
            btn_a5.Enabled = false;
            btn_b1.Enabled = false;
            btn_b2.Enabled = false;
            btn_b3.Enabled = false;
            btn_b4.Enabled = false;
            btn_b5.Enabled = false;
            btn_c1.Enabled = false;
            btn_c2.Enabled = false;
            btn_c3.Enabled = false;
            btn_c4.Enabled = false;
            btn_c5.Enabled = false;
            cb_Room.Enabled = false;

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show("File không tồn tại");
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                path = ofd.FileName;
            }
            try
            {
                if (System.IO.File.Exists(trunggian))
                {
                    DialogResult result = MessageBox.Show(
                        "File trung gian đã tồn tại. Bạn có muốn sử dụng file cũ không?\n\nChọn 'Yes' để dùng file cũ\nChọn 'No' để tạo file mới",
                        "File trung gian tồn tại",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.No)
                    {
                        var json = File.ReadAllText(path);
                        var readOpt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var defs = JsonSerializer.Deserialize<RootDef>(json, readOpt);
                        if (defs == null || defs.Movies == null || defs.Movies.Count == 0)
                        {
                            MessageBox.Show("Input sai.");
                            return;
                        }
                        var state = BuildFreshState(defs);
                        var opt = new JsonSerializerOptions { WriteIndented = true };
                        var stateJson = JsonSerializer.Serialize(state, opt);

                        var outPath = Path.GetFullPath(trunggian);
                        File.WriteAllText(outPath, stateJson);
                        MessageBox.Show("Đã ghi file tại:\n" + outPath);
                    }
                }
                else
                {
                    var json = File.ReadAllText(path);
                    var readOpt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var defs = JsonSerializer.Deserialize<RootDef>(json, readOpt);
                    if (defs == null || defs.Movies == null || defs.Movies.Count == 0)
                    {
                        MessageBox.Show("Input sai.");
                        return;
                    }
                    var state = BuildFreshState(defs);
                    var opt = new JsonSerializerOptions { WriteIndented = true };
                    var stateJson = JsonSerializer.Serialize(state, opt);

                    var outPath = Path.GetFullPath(trunggian);
                    File.WriteAllText(outPath, stateJson);
                    MessageBox.Show("Đã ghi file tại:\n" + outPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            var jsonText = File.ReadAllText(trunggian);
            var optionMovie = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var movieState = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonText, optionMovie);
            if (movieState != null)
            {
                foreach (var mv in movieState.Keys)
                {
                    cb_Movie.Items.Add(mv);
                }
            }
        }
        private void cb_Movie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMovie = cb_Movie.SelectedItem.ToString();
            var jsonText = File.ReadAllText(trunggian);
            var optionMovie = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var movieState = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonText, optionMovie);
            cb_Room.Items.Clear();
            if (movieState != null && movieState.ContainsKey(selectedMovie))
            {
                cb_Room.Enabled = true;
                var movieObj = movieState[selectedMovie] as JsonElement?;
                if (movieObj.HasValue)
                {
                    var roomMap = movieObj.Value.GetProperty("room");
                    foreach (var room in roomMap.EnumerateObject())
                    {
                        cb_Room.Items.Add(room.Name);
                    }
                }
            }
        }

        private void cb_Room_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMovie = cb_Movie.SelectedItem.ToString();
            var selectedRoom = cb_Room.SelectedItem.ToString();
            var jsonText = File.ReadAllText(trunggian);
            var optionMovie = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var movieState = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonText, optionMovie);

            if (movieState != null && movieState.ContainsKey(selectedMovie))
            {
                var movieObj = (JsonElement)movieState[selectedMovie];
                var roomMap = movieObj.GetProperty("room");

                if (roomMap.TryGetProperty(selectedRoom, out JsonElement seatMap))
                {
                    btn_a1.Enabled = true;
                    btn_a2.Enabled = true;
                    btn_a3.Enabled = true;
                    btn_a4.Enabled = true;
                    btn_a5.Enabled = true;
                    btn_b1.Enabled = true;
                    btn_b2.Enabled = true;
                    btn_b3.Enabled = true;
                    btn_b4.Enabled = true;
                    btn_b5.Enabled = true;
                    btn_c1.Enabled = true;
                    btn_c2.Enabled = true;
                    btn_c3.Enabled = true;
                    btn_c4.Enabled = true;
                    btn_c5.Enabled = true;

                    foreach (var seat in seatMap.EnumerateObject())
                    {
                        string seatName = seat.Name.ToUpper();
                        int status = seat.Value.GetInt32();

                        Button seatButton = seatName switch
                        {
                            "A1" => btn_a1,
                            "A2" => btn_a2,
                            "A3" => btn_a3,
                            "A4" => btn_a4,
                            "A5" => btn_a5,
                            "B1" => btn_b1,
                            "B2" => btn_b2,
                            "B3" => btn_b3,
                            "B4" => btn_b4,
                            "B5" => btn_b5,
                            "C1" => btn_c1,
                            "C2" => btn_c2,
                            "C3" => btn_c3,
                            "C4" => btn_c4,
                            "C5" => btn_c5,
                            _ => null
                        };

                        if (seatButton != null)
                        {
                            if (status == 0)
                            {
                                seatButton.Enabled = true;
                                seatButton.BackColor = Color.Green;
                            }
                            else
                            {
                                seatButton.Enabled = false;
                                seatButton.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }

        private string selectedSeat = "";
        private double GetSeatPrice(string seatName)
        {
            if (seatName == "A1" || seatName == "A5" || seatName == "C1" || seatName == "C5")
                return 0.25;
            if (seatName == "B2" || seatName == "B3" || seatName == "B4")
                return 2.0;
            if (seatName == "A2" || seatName == "A3" || seatName == "A4" ||
                seatName == "C2" || seatName == "C3" || seatName == "C4")
                return 1.0;
            return 1.0;
        }

        private void btn_a1_Click(object sender, EventArgs e)
        {
            HandleSelectSeat("A1");
        }

        private void btn_a2_Click(object sender, EventArgs e)
        {

        }

        private void btn_a3_Click(object sender, EventArgs e)
        {

        }

        private void btn_a4_Click(object sender, EventArgs e)
        {

        }

        private void btn_a5_Click(object sender, EventArgs e)
        {

        }

        private void btn_b1_Click(object sender, EventArgs e)
        {

        }

        private void btn_b2_Click(object sender, EventArgs e)
        {

        }

        private void btn_b3_Click(object sender, EventArgs e)
        {

        }

        private void btn_b4_Click(object sender, EventArgs e)
        {

        }

        private void btn_b5_Click(object sender, EventArgs e)
        {

        }

        private void btn_c1_Click(object sender, EventArgs e)
        {

        }

        private void btn_c2_Click(object sender, EventArgs e)
        {

        }

        private void btn_c3_Click(object sender, EventArgs e)
        {

        }

        private void btn_c4_Click(object sender, EventArgs e)
        {

        }

        private void btn_c5_Click(object sender, EventArgs e)
        {

        }
        private void btn_a4_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("A4");
        }
        private void btn_a2_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("A2");
        }
        private void btn_a3_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("A3");
        }
        private void btn_a5_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("A5");
        }

        private void btn_b1_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("B1");
        }

        private void btn_b2_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("B2");
        }

        private void btn_b3_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("B3");
        }

        private void btn_b4_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("B4");
        }

        private void btn_b5_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("B5");
        }

        private void btn_c1_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("C1");
        }

        private void btn_c2_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("C2");
        }

        private void btn_c3_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("C3");
        }

        private void btn_c4_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("C4");
        }

        private void btn_c5_Click_1(object sender, EventArgs e)
        {
            HandleSelectSeat("C5");
        }

        private Button GetSeatButtonByName(string seatName)
        {
            return seatName switch
            {
                "A1" => btn_a1,
                "A2" => btn_a2,
                "A3" => btn_a3,
                "A4" => btn_a4,
                "A5" => btn_a5,
                "B1" => btn_b1,
                "B2" => btn_b2,
                "B3" => btn_b3,
                "B4" => btn_b4,
                "B5" => btn_b5,
                "C1" => btn_c1,
                "C2" => btn_c2,
                "C3" => btn_c3,
                "C4" => btn_c4,
                "C5" => btn_c5,
                _ => null
            };
        }

        private void HandleSelectSeat(string seatName)
        {
            if (selectedSeat != "")
            {
                var previousSeatButton = GetSeatButtonByName(selectedSeat);
                if (previousSeatButton != null)
                {
                    previousSeatButton.BackColor = Color.Green;
                }
            }
            selectedSeat = seatName;
            var currentSeatButton = GetSeatButtonByName(seatName);
            if (currentSeatButton != null)
            {
                currentSeatButton.BackColor = Color.Yellow;
            }
            double priceMultiplier = GetSeatPrice(seatName);
            string jsonText = File.ReadAllText(trunggian);
            var optionMovie = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var movieState = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonText, optionMovie);
            if (movieState != null && movieState.ContainsKey(cb_Movie.SelectedItem.ToString()))
            {
                var movieObj = (JsonElement)movieState[cb_Movie.SelectedItem.ToString()];
                int basePrice = movieObj.GetProperty("cost").GetInt32();
                double finalPrice = basePrice * priceMultiplier;
                tb_result.Text = "Price: " + finalPrice.ToString();
            }
        }

        private void btn_result_Click(object sender, EventArgs e)
        {

        }
        private void btn_result_Click_1(object sender, EventArgs e)
        {
            if (selectedSeat == "")
            {
                MessageBox.Show("Vui lòng chọn ghế trước khi đặt vé.");
                return;
            }
            if (tb_NameCustomer.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                return;
            }
            if (cb_Movie.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim.");
                return;
            }
            if (cb_Room.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng.");
                return;
            }
            string selectedMovie = cb_Movie.SelectedItem.ToString();
            string selectedRoom = cb_Room.SelectedItem.ToString();
            string jsonText = File.ReadAllText(trunggian);
            var optionMovie = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var movieState = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonText, optionMovie);
            if (movieState != null && movieState.ContainsKey(selectedMovie))
            {
                var movieObj = (JsonElement)movieState[selectedMovie];
                var roomMap = movieObj.GetProperty("room");
                var seatMap = roomMap.GetProperty(selectedRoom);
                var seatDict = new Dictionary<string, int>();
                foreach (var seat in seatMap.EnumerateObject())
                {
                    seatDict[seat.Name] = seat.Value.GetInt32();
                }
                seatDict[selectedSeat] = 1;
                var updatedSeatMap = new Dictionary<string, int>(seatDict);
                var updatedRoomMap = new Dictionary<string, object>();
                foreach (var room in roomMap.EnumerateObject())
                {
                    if (room.Name == selectedRoom)
                    {
                        updatedRoomMap[room.Name] = updatedSeatMap;
                    }
                    else
                    {
                        updatedRoomMap[room.Name] = JsonSerializer.Deserialize<Dictionary<string, int>>(room.Value.GetRawText());
                    }
                }
                var updatedMovieObj = new Dictionary<string, object>
                {
                    ["cost"] = movieObj.GetProperty("cost").GetInt32(),
                    ["room"] = updatedRoomMap
                };
                movieState[selectedMovie] = updatedMovieObj;
                var opt = new JsonSerializerOptions { WriteIndented = true };
                var stateJson = JsonSerializer.Serialize(movieState, opt);
                File.WriteAllText(trunggian, stateJson);
                MessageBox.Show("Đặt vé thành công cho " + tb_NameCustomer.Text + " tại ghế " + selectedSeat);
                cb_Room_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        private async void btn_saveOutPut_Click(object sender, EventArgs e)
        {
            ProgressBar? pb = null;
            try
            {
                if (!File.Exists(trunggian))
                {
                    MessageBox.Show("Chưa có file trung gian.");
                    return;
                }

                string jsonText = File.ReadAllText(trunggian);
                var movieState = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonText, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (movieState == null || movieState.Count == 0)
                {
                    MessageBox.Show("Dữ liệu rỗng.");
                    return;
                }

                int totalSold = 0;
                foreach (var mv in movieState)
                {
                    var movieObj = mv.Value;
                    if (!movieObj.TryGetProperty("room", out var roomMapElement)) continue;
                    var roomMap = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(roomMapElement.GetRawText());
                    if (roomMap == null) continue;
                    foreach (var room in roomMap)
                    {
                        totalSold += room.Value.Count(kv => kv.Value == 1);
                    }
                }

                pb = new ProgressBar
                {
                    Minimum = 0,
                    Maximum = Math.Max(1, totalSold),
                    Value = 0,
                    Width = Math.Max(200, btn_saveOutPut.Width),
                    Height = 22,
                    Style = ProgressBarStyle.Continuous,
                    Location = new Point(btn_saveOutPut.Left, btn_saveOutPut.Bottom + 10)
                };
                Controls.Add(pb);
                pb.BringToFront();
                pb.Visible = true;
                Refresh();

                var soldSeats = new List<Dictionary<string, object>>();
                double totalRevenue = 0;

                if (totalSold > 0)
                {
                    int perStepDelayMs = Math.Max(10, 5000 / totalSold);

                    foreach (var mv in movieState)
                    {
                        string movieName = mv.Key;
                        var movieObj = mv.Value;

                        int basePrice = movieObj.GetProperty("cost").GetInt32();
                        var roomMapElement = movieObj.GetProperty("room");
                        var roomMap = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(roomMapElement.GetRawText());
                        if (roomMap == null) continue;

                        foreach (var room in roomMap)
                        {
                            string roomName = room.Key;
                            foreach (var seat in room.Value)
                            {
                                if (seat.Value == 1)
                                {
                                    string seatName = seat.Key.ToUpperInvariant();
                                    double multiplier = GetSeatPrice(seatName);
                                    double price = basePrice * multiplier;
                                    totalRevenue += price;

                                    string seatType = multiplier switch
                                    {
                                        0.25 => "Vớt",
                                        1.0 => "Thường",
                                        2.0 => "VIP",
                                        _ => "Thường"
                                    };

                                    soldSeats.Add(new Dictionary<string, object>
                                    {
                                        ["movie"] = movieName,
                                        ["room"] = roomName,
                                        ["seat"] = seatName,
                                        ["type"] = seatType,
                                        ["price"] = price
                                    });

                                    if (pb.Value < pb.Maximum)
                                    {
                                        pb.Value += 1;
                                        pb.Refresh();
                                        await Task.Delay(perStepDelayMs);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    pb.Maximum = 100;
                    for (int i = 1; i <= 100; i++)
                    {
                        pb.Value = i;
                        pb.Refresh();
                        await Task.Delay(50);
                    }
                }

                var exportObject = new Dictionary<string, object>
                {
                    ["soldSeats"] = soldSeats,
                    ["totalRevenue"] = totalRevenue
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string outJson = JsonSerializer.Serialize(exportObject, options);
                File.WriteAllText(out_path, outJson);

                MessageBox.Show("Đã lưu báo cáo JSON vào:\n" + out_path, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (pb != null)
                {
                    Controls.Remove(pb);
                    pb.Dispose();
                }
            }
        }
    }
}
