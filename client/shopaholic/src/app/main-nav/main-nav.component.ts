import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthenticationService } from '../user/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {
 public UserLoggedIn: any;
 
 
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,
    private authService: AuthenticationService,
    private _router: Router) {
   
     this.UserLoggedIn =  this.authService.user$;
     console.log(this.UserLoggedIn);
  }
  logout() {
    this.authService.logout();
  }
  login() {
    console.log('login');
    this._router.navigate(['/login']);
  }
}
