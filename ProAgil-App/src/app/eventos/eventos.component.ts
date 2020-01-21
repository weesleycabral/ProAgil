import { Component, OnInit, TemplateRef } from '@angular/core';
import { ThrowStmt } from '@angular/compiler';
import { EventoService } from '../services/evento.service';
import { Evento } from '../models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  _filtroLista: string;
  eventosFiltrados: Evento[];
  modalRef: BsModalRef;

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService
  ) { }

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
     evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getEventos() {
     this.eventoService.getAllEvento().subscribe(
      (_eventos: Evento[]) => {
      this.eventos = _eventos;
      this.eventosFiltrados = _eventos;
      console.log(this.eventos);
    }, error => {
      console.log(error);
    });
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

}
