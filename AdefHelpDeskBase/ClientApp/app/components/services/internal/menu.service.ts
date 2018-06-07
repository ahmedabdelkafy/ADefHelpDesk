﻿import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MenuItem } from 'primeng/primeng';
import { IUser } from '../../classes/user';

@Injectable()
export class MenuService {
    getMenu(user: IUser): MenuItem[] {
        // Build Menu
        let BaseItems: MenuItem[] = [];
        let LoggedInItems: MenuItem[] = [];
        let SuperUserItems: MenuItem[] = [];

        BaseItems.push(
            {
                label: 'Home',
                icon: 'fa fa-fw fa-home', routerLink: ['/home']
            });

        LoggedInItems.push(
            {
                label: 'Existing Tickets',
                icon: 'fa fa-fw fa-ticket', routerLink: ['/tickets']
            },
            {
                label: 'Reports',
                icon: 'fa fa-fw fa-files-o', routerLink: ['/reports']
            });

        SuperUserItems.push(
            {
                label: 'Administration', icon: 'fa fa-fw fa fa-university',
                items: [
                    {
                        label: 'User Manager',
                        icon: 'fa fa-fw fa fa-users', routerLink: ['/usermanager']
                    },
                    {
                        label: 'Roles',
                        icon: 'fa fa-fw fa fa-address-book-o', routerLink: ['/userassignmentroles']
                    },
                    {
                        label: 'Tags',
                        icon: 'fa fa-fw fa-sliders', routerLink: ['/tagsadmin']
                    },
                    {
                        label: 'Email',
                        icon: 'fa fa-fw fa-envelope-o', routerLink: ['/emailadmin']
                    },
                    {
                        label: 'Upgrade Application',
                        icon: 'fa fa-fw fa fa-cloud-upload', routerLink: ['/upgrade']
                    },
                    {
                        label: 'Application Settings',
                        icon: 'fa fa-fw fa fa-cog', routerLink: ['/applicationsettings']
                    },
                    {
                        label: 'API Security',
                        icon: 'fa fa-fw fa fa-lock', routerLink: ['/apisecurity']
                    },
                    {
                        label: 'System Files',
                        icon: 'fa fa-fw fa fa-folder', routerLink: ['/filemanager']
                    },
                    {
                        label: 'System Logs',
                        icon: 'fa fa-fw fa fa-database ', routerLink: ['/systemlogs']
                    },
                ]
            });

        if (user.isLoggedIn) {
            BaseItems = BaseItems.concat(LoggedInItems);
        }

        if (user.isSuperUser) {
            BaseItems = BaseItems.concat(SuperUserItems);
        }

        return BaseItems;
    }
}