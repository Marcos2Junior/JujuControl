import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  filtro: string;
  get filtroLista(): string {
    return this.filtro;
  }
  set filtroLista(value: string) {
    this.filtro = value;
    this.usuariosFiltrados = this.filtroLista ? this.filtrarUsuarios(this.filtroLista) : this.usuarios;
  }

  usuariosFiltrados: any = [];
  usuarios: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getUsuarios();
  }

  filtrarUsuarios(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.usuarios.filter(
      usuario => usuario.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getUsuarios() {
    this.http.get('http://localhost:44343/api/usuarios').subscribe(response => {
      this.usuarios = response;
      console.log(response);
    }, error => {
      console.log(error);
    }
    );
  }
}
