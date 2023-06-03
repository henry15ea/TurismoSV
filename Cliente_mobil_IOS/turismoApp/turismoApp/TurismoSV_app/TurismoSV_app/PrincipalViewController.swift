//
//  PrincipalViewController.swift
//  TurismoSV_app
//
//  Created by HenryGuzman on 6/1/23.
//  Copyright © 2023 HenryGuzman. All rights reserved.
//

import UIKit

class PrincipalViewController: UIViewController, UITabBarDelegate {

    @IBOutlet weak var NavBarBottom: UITabBar!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        //self.tabBarController?.delegate = self;
        self.NavBarBottom.delegate = self;
        // Do any additional setup after loading the view.
    }//end func

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }//end func
    
    func tabBar(_ tabBar: UITabBar, didSelect item: UITabBarItem) {
        switch item.tag { // Realizar acciones específicas según el tag del item presionado
        case 0:
        // Acciones para el primer item
            print("has presionado 1");
            
            
            self.performSegue(withIdentifier: "categoriasView", sender: self);
        case 1:
        // Acciones para el segundo item
            print("has presionado 2");
            self.performSegue(withIdentifier: "paquetesView", sender: self);
        case 2:
        // Acciones para el tercer item
            print("has presionado 3");
            self.performSegue(withIdentifier: "historialView", sender: self);
        case 3:
        // Acciones para el cuarto item
            print("has presionado 4");
            self.performSegue(withIdentifier: "cuentaView", sender: self);
        default:
            break
        }
    }
    //end fun

}//end class
