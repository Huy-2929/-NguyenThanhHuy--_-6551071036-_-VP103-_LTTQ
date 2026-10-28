using Microsoft.EntityFrameworkCore;
using ThongTinSach.Models;

namespace ThongTinSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += async (s, e) => await Form1_Load(s, e);
        }



        private DuLieuContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DuLieuContext>().UseSqlServer(
                @"Server=localhost\SQLEXPRESS; Database=DuLieu;Trusted_Connection=True;TrustServerCertificate=True");
            return new DuLieuContext(optionsBuilder.Options);
        }
        private async Task Form1_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
            ClearInputs();
        }

        private void ClearInputs()
        {
            dgvThongTinSach.ClearSelection();
            dgvThongTinSach.CurrentCell = null;

            txtGiaSach.Clear();
            txtMaSach.Clear();
            txtTenTheLoai.Clear();

            SetButtonStates(false);
        }

        private async Task LoadDataAsync()
        {
            using var context = CreateContext();
            var danhSach = await context.CongViecs.AsNoTracking().OrderBy(c => c.MaSach).ToListAsync();
            dgvThongTinSach.DataSource = danhSach;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }
            try
            {
                using var context = CreateContext();
                string maSach = txtMaSach.Text.Trim();
                if (await context.CongViecs.AnyAsync(c => c.MaSach == maSach))
                {
                    MessageBox.Show("Mã sách đã tồn tại. Vui lòng nhập mã sách khác.");
                    return;
                }
                var congViec = new CongViec
                {
                    MaSach = txtMaSach.Text.Trim(),
                    TenSach = txtTenTheLoai.Text.Trim(),
                    GiaTien = txtGiaSach.Text.Trim()
                };
                context.CongViecs.Add(congViec);
                await context.SaveChangesAsync();
                MessageBox.Show("Thêm thành công!");
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }
            try
            {
                using var context = CreateContext();
                var maSach = txtMaSach.Text.Trim();
                var congViec = await context.CongViecs.FirstOrDefaultAsync(c => c.MaSach == maSach);
                if (congViec != null)
                {
                    congViec.TenSach = txtTenTheLoai.Text.Trim();
                    congViec.GiaTien = txtGiaSach.Text.Trim();
                    await context.SaveChangesAsync();
                    MessageBox.Show("Sửa thành công!");
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                ClearInputs();
                return; // Người dùng chọn "No", không thực hiện xóa
            }
            try
            {
                using var context = CreateContext();
                var item = await context.CongViecs.FirstOrDefaultAsync(c => c.MaSach == txtMaSach.Text.Trim());
                if (item != null)
                {
                    context.CongViecs.Remove(item);
                    await context.SaveChangesAsync();
                    MessageBox.Show("Xóa thành công!");
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }



        private void dgvThongTinSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThongTinSach.CurrentRow == null || dgvThongTinSach.CurrentRow.Index < 0 || dgvThongTinSach.CurrentRow.IsNewRow)
            {
                return;
            }

            if (dgvThongTinSach.CurrentRow.DataBoundItem is CongViec item)
            {
                txtMaSach.Text = item.MaSach ?? string.Empty;
                txtTenTheLoai.Text = item.TenSach ?? string.Empty;
                txtGiaSach.Text = item.GiaTien ?? string.Empty;
            }
            else
            {
                txtMaSach.Text = dgvThongTinSach.CurrentRow.Cells["MaSach"]?.Value?.ToString() ?? string.Empty;
                txtTenTheLoai.Text = dgvThongTinSach.CurrentRow.Cells["TenSach"]?.Value?.ToString() ?? string.Empty;
                txtGiaSach.Text = dgvThongTinSach.CurrentRow.Cells["GiaTien"]?.Value?.ToString() ?? string.Empty;
            }
            SetButtonStates(true);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Mã sách không được để trống.");
                txtMaSach.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenTheLoai.Text))
            {
                MessageBox.Show("Tên sách không được để trống.");
                txtTenTheLoai.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGiaSach.Text))
            {
                MessageBox.Show("Giá sách không được để trống.");
                txtGiaSach.Focus();
                return false;
            }

           
            string giaSachText = txtGiaSach.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(giaSachText, 
                System.Globalization.NumberStyles.AllowDecimalPoint, 
                System.Globalization.CultureInfo.InvariantCulture, out decimal giaSach) || 
                giaSach < 0)
            {
                MessageBox.Show("Giá sách chỉ được nhập số thực hoặc số nguyên.");
                txtGiaSach.Focus();
                return false;
            }

            return true;
        }

        private void SetButtonStates(bool isEditing)
        {
            btnThem.Enabled = !isEditing;
            btnSua.Enabled = isEditing;
            btnXoa.Enabled = isEditing;
            btnThoat.Enabled = true;
        }

    }
}
