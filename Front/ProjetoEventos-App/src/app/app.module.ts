import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { NavComponent } from './shared/nav/nav.component';
import { EventoService } from './services/evento.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { NgxSpinnerModule } from 'ngx-spinner';
import { TituloComponent } from './shared/titulo/titulo.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';




@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
      NavComponent,
      TituloComponent,
      ContatosComponent,
      PerfilComponent,
      DashboardComponent,
      DateTimeFormatPipe,
      EventoDetalheComponent,
      EventoListaComponent,
      UserComponent,
      LoginComponent,
      RegistrationComponent

   ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgxSpinnerModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot(
      {
        timeOut: 3000,
        positionClass: 'toast-bottom-right',
        preventDuplicates: true,
        progressBar: true
      })
  ],

  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [EventoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
