using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data;
using Model;

namespace Presentacion
{
    public partial class VistaShipper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                TraerShipperGridViewDT();
                TraerCompanyCbName();

            }

        }

        private void TraerShipperGridViewDT()
        {
            DataTable dt = DacShipper.ListarDS();

            DataRow nuevaFila = dt.NewRow();

            gridShippers.DataSource = dt;
            gridShippers.DataBind();

        }


        private void TraerCompanyCbName() 
        {
            List<string> names = DacShipper.ListarCompany();

            names.Insert(0, "[Todas]");
            cbCompany.DataSource = names;
            cbCompany.DataBind();
        }

        protected void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string company = cbCompany.SelectedValue.ToString();

            if (company == "[Todas]")
            {
                TraerShipperGridViewDT();
            }
            else 
            {
                gridShippers.DataSource = DacShipper.TraerUno(company);
                gridShippers.DataBind();
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Shipper shipper = new Shipper();
            shipper.CompName = txtCompaName.Text;
            shipper.Phone = txtPhone.Text;

            DacShipper.Insertar(shipper);
            gridShippers.DataSource = null;
            TraerShipperGridViewDT();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtShipid.Text;
            DacShipper.Eliminar(id);
            gridShippers.DataSource = null;
            TraerShipperGridViewDT();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Shipper shipper = new Shipper();
            shipper.CompName = txtCompaName.Text;
            shipper.Phone = txtPhone.Text;
            shipper.ShipId = txtShipid.Text;

            DacShipper.Actualizar(shipper);
            gridShippers.DataSource = null;
            TraerShipperGridViewDT();
        }

        protected void gridShippers_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = gridShippers.SelectedIndex + 1;
            DataTable dt = DacShipper.ListarOrdenes(index.ToString());

            DataRow nuevaFila = dt.NewRow();

            gridOrders.DataSource = dt;
            gridOrders.DataBind();

        }
    }
}