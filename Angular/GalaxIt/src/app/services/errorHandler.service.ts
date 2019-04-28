import { ErrorHandler, Injectable} from "@angular/core";
import { Router} from "@angular/router";
import { HttpErrorResponse } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService implements ErrorHandler {
  
  constructor(private router: Router){};
               

  public handleError(error: HttpErrorResponse) {

    if(error.status === 400){
      console.log('Error 400 BAD REQUEST:', error.message);
      alert('Il y a eu un problème avec la demande: ' + error.message);
      this.router.navigate(['']);
    }
    else if(error.status === 401){
      console.log('Error 401 UNAUTHORIZED', error.message);
      alert('Problème d\'authentification!');
      this.router.navigate(['']);
    }
    else if(error.status === 403){
      console.log('Error 403 UNAUTHORIZED', error.message);
      alert('Vous n\'avez pas les permissions nécessaires. Vous devez être administrateur pour accéder à ce contenu');
      this.router.navigate(['']);
    }
    else if(error.status === 404){
      console.log('Error 404 NOT FOUND:', error.message);
    }
    else if(error.status === 405){
      console.log('Error 405 NOT ALLOWED:', error.message);
      alert("La demande ne peut pas être exécutée a cet instant.");
      this.router.navigate(['']);
    }
    else if(error.status === 409){
      console.log('Error 409 CONFLICT:', error.message);
      alert("Edition concurrente! (Rique de lost Update)");
      this.router.navigate(['']);
    }
    else if(error.status === 500){
      console.log('Error ', error.message);
      alert('Le serveur a rencontré un problème, veuillez réessayer plsu tard.');
      this.router.navigate(['']);
    }
    else{
      console.log('Error:', error.message);
      alert('Il y a eu une erreur: ' + error.message);
      this.router.navigate(['']);
    }
  }
  
  
}