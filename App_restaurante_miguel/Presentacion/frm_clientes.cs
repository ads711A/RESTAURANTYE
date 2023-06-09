﻿using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frm_clientes : Form
    {
        public frm_clientes()
        {
            InitializeComponent();
            txt_identificacion.Enabled = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
           
            MemoryStream ms = new MemoryStream();
            if (txt_identificacion.Text == "" || txt_Nombre.Text == "" || txt_contacto.Text == "" || txt_direccion.Text == "")
            {
                MessageBox.Show("Debe ingresar toda la unformacion requerida");
            }
            cls_validar_clientes obj_validar = new cls_validar_clientes();
            if (obj_validar.fnt_validar_clientes(txt_identificacion.Text) == true)
            {
                MessageBox.Show("Este Clientes ya se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            {
                cls_agregar_clientes objAgregarClientes = new cls_agregar_clientes(
                  txt_identificacion.Text,
                  txt_Nombre.Text,
                  txt_contacto.Text,
                  txt_direccion.Text);
                MessageBox.Show("" + objAgregarClientes.getMsn());
                fnt_nuevo();

            }
        }

        private void fnt_nuevo()
        {
            txt_identificacion.Clear();
            txt_Nombre.Clear();
            txt_contacto.Clear();
            txt_direccion.Clear();
            
            txt_identificacion.Enabled = true;
            txt_identificacion.Focus();
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            fnt_nuevo();
        }

        private void fnt_consultar(string identificacion)

        {
            txt_identificacion.Enabled = false;
            cls_consultar_cliente obj_Consultar = new cls_consultar_cliente();
            obj_Consultar.fnt_Consultar(identificacion);
            txt_Nombre.Text = obj_Consultar.getNombre();
            txt_contacto.Text = obj_Consultar.getContacto();
            txt_direccion.Text = obj_Consultar.getDireccion();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
           
            cls_validar_clientes obj_validar = new cls_validar_clientes();
            if (obj_validar.fnt_validar_clientes(txt_identificacion.Text) == false)
            {
                MessageBox.Show("Este cliente no se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fnt_nuevo();
            }
           
            if (txt_identificacion.Text == "")
            {
              
                MessageBox.Show("Ingrese el criterio de busqueda");
            }
            else

                fnt_consultar(txt_identificacion.Text);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
           
            cls_actualizar_clientes objActulizarClientes = new cls_actualizar_clientes(
                
                txt_identificacion.Text,
               txt_Nombre.Text,
               txt_contacto.Text,
               txt_direccion.Text);
            MessageBox.Show("" + objActulizarClientes.getMsn());
            fnt_nuevo() ;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_identificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_contacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_direccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btn_nuevo_Click_1(object sender, EventArgs e)
        {
            fnt_nuevo();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            if (txt_identificacion.Text == "" || txt_Nombre.Text == "" || txt_contacto.Text == "" || txt_direccion.Text == "")
            {
                MessageBox.Show("Debe ingresar toda la unformacion requerida");
            }
            cls_validar_clientes obj_validar = new cls_validar_clientes();
            if (obj_validar.fnt_validar_clientes(txt_identificacion.Text) == true)
            {
                MessageBox.Show("Este Clientes ya se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            {
                cls_agregar_clientes objAgregarClientes = new cls_agregar_clientes(
                  txt_identificacion.Text,
                  txt_Nombre.Text,
                  txt_contacto.Text,
                  txt_direccion.Text);
                MessageBox.Show("Cliente registrado con exito");
                fnt_nuevo();

            }
        }

        private void btn_consultar_Click_1(object sender, EventArgs e)
        {
            cls_validar_clientes obj_validar = new cls_validar_clientes();
            if (obj_validar.fnt_validar_clientes(txt_identificacion.Text) == false)
            {
                MessageBox.Show("Este cliente no se encuentra registrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fnt_nuevo();
            }

            if (txt_identificacion.Text == "")
            {

                MessageBox.Show("Ingrese el criterio de busqueda");
            }
            else

                fnt_consultar(txt_identificacion.Text);
        }

        private void btn_actualizar_Click_1(object sender, EventArgs e)
        {
            cls_actualizar_clientes objActulizarClientes = new cls_actualizar_clientes(

              txt_identificacion.Text,
             txt_Nombre.Text,
             txt_contacto.Text,
             txt_direccion.Text);
            MessageBox.Show("" + objActulizarClientes.getMsn());
            fnt_nuevo();
        }


        private void fnt_login(string user, string password)
        {


            cls_login obj_login = new cls_login(user, password);
            if (obj_login.getRol() == "Administrador")
            {
                FormPrincipal obj_admin = new FormPrincipal();
                this.Hide();
                obj_admin.Visible = true;
                obj_login.getNombre();
                obj_admin.lbl_encargado.Text = obj_login.getNombre();
                obj_admin.lbl_estado.Text = obj_login.getEstado();
                obj_admin.lbl_rol.Text = obj_login.getRol();
                obj_admin.lbl_usuario.Text = lbl_usuario.Text;
                obj_admin.lbl__contraseña.Text = lbl__contraseña.Text;

                Visible = false;
            }

            if (obj_login.getRol() == "Cajero")
            {
                frm_cajero obj_admin = new frm_cajero();
                this.Hide();
                obj_admin.Visible = true;
                obj_login.getNombre();
                obj_admin.lbl_encargado.Text = obj_login.getNombre();
                obj_admin.lbl_estado.Text = obj_login.getEstado();
                obj_admin.lbl_rol.Text = obj_login.getRol();
                obj_admin.lbl_usuario.Text = lbl_usuario.Text;
                obj_admin.lbl__contraseña.Text = lbl__contraseña.Text;

                Visible = false;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            fnt_login(lbl_usuario.Text, lbl__contraseña.Text);


        }

        private void btn_Cerarr_Click(object sender, EventArgs e)
        {
            Visible = false;
            frm_login obj_Login = new frm_login();
            obj_Login.Visible = true;
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();



        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
    }

