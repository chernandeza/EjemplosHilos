using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SubProcesosGUI
{
    public partial class frmPrincipal : Form
    {
        Corredor cr1;
        Corredor cr2;
        Corredor cr3;
        private bool _simRunning = false;

        /* El cancelation token permite finalizar tareas de forma inmediata sin esperar.
         * Esto es necesario cuando un corredor finaliza, para que los demás se detengan
         */
        CancellationTokenSource cts = new CancellationTokenSource();
        
        public frmPrincipal()
        {
            InitializeComponent();

            //Creación de los 3 corredores
            cr1 = new Corredor();
            cr2 = new Corredor();
            cr3 = new Corredor();

            //Suscripción a los eventos de los corredores
            cr1.ValueChanged += new EventHandler(cr1_ValueChanged);
            cr2.ValueChanged += new EventHandler(cr2_ValueChanged);
            cr3.ValueChanged += new EventHandler(cr3_ValueChanged);
            cr1.MaxReached += new EventHandler(cr1_MaxReached);
            cr2.MaxReached += new EventHandler(cr2_MaxReached);
            cr3.MaxReached += new EventHandler(cr3_MaxReached);

            //Método que se llama cuando se realiza la cancelación de las tareas
            cts.Token.Register(() => cr1.Detenerse());
            cts.Token.Register(() => cr2.Detenerse());
            cts.Token.Register(() => cr3.Detenerse());
        }

        void cr3_MaxReached(object sender, EventArgs e)
        {
            //Corredor 3 ganó, cancelar tareas
            cts.Cancel();
            MessageBox.Show("¡El corredor 3 ganó la competencia!", "SubProcesosGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        void cr1_MaxReached(object sender, EventArgs e)
        {
            //Corredor 1 ganó, cancelar tareas
            cts.Cancel();
            MessageBox.Show("¡El corredor 1 ganó la competencia!", "SubProcesosGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void cr2_MaxReached(object sender, EventArgs e)
        {
            //Corredor 2 ganó, cancelar tareas
            cts.Cancel();
            MessageBox.Show("¡El corredor 2 ganó la competencia!", "SubProcesosGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void cr3_ValueChanged(object sender, EventArgs e)
        {
            /* El invoke sobre el form debe realizarse cuando un hilo que no es el principal de la 
             * clase, intenta cambiar controles de GUI. El llamado al delegate de invoke evita que
             * varios hilos intenten cambiar la GUI al mismo tiempo. Esto es sincornización de 
             * subprocesos a nivel de GUI.
             */

            this.BeginInvoke(new MethodInvoker(delegate
            {
                pbCorredor3.Value = cr3.Estado.Value;
                lblCr3.Text = cr3.Estado.Value + "%";
            }));
        }

        void cr2_ValueChanged(object sender, EventArgs e)
        {
            /* El invoke sobre el form debe realizarse cuando un hilo que no es el principal de la 
             * clase, intenta cambiar controles de GUI. El llamado al delegate de invoke evita que
             * varios hilos intenten cambiar la GUI al mismo tiempo. Esto es sincornización de 
             * subprocesos a nivel de GUI.
             */
            this.BeginInvoke(new MethodInvoker(delegate
            {
                pbCorredor2.Value = cr2.Estado.Value;
                lblCr2.Text = cr2.Estado.Value + "%";
            }));            
        }

        void cr1_ValueChanged(object sender, EventArgs e)
        {
            /* El invoke sobre el form debe realizarse cuando un hilo que no es el principal de la 
             * clase, intenta cambiar controles de GUI. El llamado al delegate de invoke evita que
             * varios hilos intenten cambiar la GUI al mismo tiempo. Esto es sincronización de 
             * subprocesos a nivel de GUI.
             */
            this.BeginInvoke(new MethodInvoker(delegate
            {
                pbCorredor1.Value = cr1.Estado.Value;
                lblCr1.Text = cr1.Estado.Value + "%";
            }));            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Comprueba que la simulación esté corriendo
            if (!_simRunning)
            {
                //Inicia las tareas (subprocesos)
                Task corredor1 = new Task(() => cr1.Correr(cts.Token));
                Task corredor2 = new Task(() => cr2.Correr(cts.Token));
                Task corredor3 = new Task(() => cr3.Correr(cts.Token));

                corredor1.Start();
                corredor2.Start();
                corredor3.Start();

                btnStart.Text = "Detener";
                _simRunning = true;
            }
            else
            {
                //Si se presionó el botón de Detener, se cancelan las tareas.
                cts.Cancel();
                //btnStart.Text = "Salir";
                DialogResult dr = MessageBox.Show("¿Desea salir?", "Subrocesamiento en GUI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }                    
                else
                {
                    _simRunning = false;
                }                 
            }
        }
    }
}
