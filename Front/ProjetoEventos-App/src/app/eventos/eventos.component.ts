import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  private _filtroLista: string = '';

  larguraImagem: number = 50;
  margemImagem: number = 2;
  exibirImagem: boolean = true;

  constructor(private http: HttpClient) { }


  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
     this.http.get('https://localhost:5001/api/eventos').subscribe(
         response =>
           {
            this.eventos = response;
            this.eventosFiltrados = this.eventos
          },
           error => console.log(error)
      );
  }

  public get filtroLista() : string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){

    this._filtroLista = value;
    this.eventosFiltrados =
    this._filtroLista ? this.filtrarEventos(this._filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor:string) :any{

    filtrarPor= filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(

      (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
}

}