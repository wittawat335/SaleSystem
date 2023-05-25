import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Menu } from 'src/app/Interfaces/menu';
import { MenuService } from 'src/app/services/menu.service';
import { UtilityService } from 'src/app/services/utility.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
})
export class LayoutComponent implements OnInit {
  listMenu: Menu[] = [];
  userName: string = '';
  roleUser: string = '';

  constructor(
    private router: Router,
    private menuService: MenuService,
    private utService: UtilityService
  ) {}

  ngOnInit(): void {}

  getMenu() {
    const user = this.utService.getSessionUser();
    if (user != null) {
      this.userName = user.fullName;
      this.roleUser = user.roleName;

      this.menuService.GetList(user.userId).subscribe({
        next: (data) => {
          if (data.status) this.listMenu = data.value;
        },
        error: (e) => {},
      });
    }
  }

  logOut() {
    this.utService.removeSessionUser();
    this.router.navigate(['login']);
  }
}
