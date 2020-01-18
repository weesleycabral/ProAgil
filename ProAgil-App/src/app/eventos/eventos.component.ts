import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  eventos: any = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  _filtroLista: string;
  eventosFiltrados: any = [];


  constructor(
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
     evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getEventos(): any {
    this.eventos = this.http.get('http://localhost:5000/api/eventos').subscribe(response => {
      this.eventos = response;
      this.eventosFiltrados = response;
      console.log(this.eventos);
    }, error => {
      console.log(error);
    });
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

}
