import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {


  modalRef = new BsModalRef();


  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  private _filtroLista: string = '';

  public larguraImagem: number = 100;
  public margemImagem: number = 2;
  public exibirImagem: boolean = true;



  constructor(private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router

    ) { }





  public alterarImagem(): void{
    this.exibirImagem = !this.exibirImagem;
  }

  public ngOnInit(): void {

    this.spinner.show();
      this.getEventos();
  }

   public getEventos(): void {
     this.eventoService.getEventos().subscribe({
         next: (eventos: Evento[]) =>{
            this.eventos = eventos;
            this.eventosFiltrados = this.eventos
          },

          error: (error: any) => {
            this.spinner.hide()
            this.toastr.error('Erro ao Carregar os Eventos!', 'ERRO!');

          },

          complete: () => this.spinner.hide()

     });
}



  public get filtroLista() : string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){

    this._filtroLista = value;
    this.eventosFiltrados =
    this._filtroLista ? this.filtrarEventos(this._filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor:string) : Evento[]{

    filtrarPor= filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(

      (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
}



openModal(template: TemplateRef<any>) {
  this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
}

confirm(): void {

  this.modalRef.hide();
  this.toastr.success('Yes Baby! Thank You!', 'Evento deletado com sucesso!')
}

decline(): void {

  this.modalRef.hide();

}

detalheEvento(id:number):void{
  this.router.navigate(([`eventos/detalhe/${id}`]));
}


}
