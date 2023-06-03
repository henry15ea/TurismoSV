//
//  CategoriaViewController.swift
//  TurismoSV_app
//
//  Created by HenryGuzman on 6/2/23.
//  Copyright © 2023 HenryGuzman. All rights reserved.
//

import UIKit

class CategoriaViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
   
    
    //variables de usuario
    let dataController = CategoriasController();
    var categorias = [categoriasResponseModel.dataResponseModel]();
    
    //enlace a widgets
    
    @IBOutlet weak var categoriasTabla: UITableView!
    
    private func fn_load(){
        var resp:Bool = false;
        
        dataController.fn_GetCategorias(){ success in
            DispatchQueue.main.async {
                if success {
                    let dataModels = self.dataController.getData()
                
                    self.categorias = dataModels!;
                    
                    self.categoriasTabla.reloadData();
                    /*
                    for dataModel in dataModels! {
                        for dataModel in dataModels! {
                            let categoria = categoriasResponseModel.dataResponseModel(Idcategoria: dataModel.Idcategoria, Nombre: dataModel.Nombre, Descripcion: dataModel.Descripcion)
                            self.categorias.append(categoria)
                        }
                    }
                     */
                    
                }else{
                    
                    
                }
            }
        }
        
    }//end func
    
    
    override func viewDidLoad() {
       super.viewDidLoad()
    
        //incializamos la tabla
       self.categoriasTabla.delegate = self
       self.categoriasTabla.dataSource = self
        
        //llamamos a la api
        self.fn_load();
        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    //funciones propias de tableview
            func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
                return self.categorias.count;
            }
            
            func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
                // Obtén una instancia de la celda de la tabla desde el storyboard
                guard let cell = tableView.dequeueReusableCell(withIdentifier: "celdaCategoria")
                    else {
                        return UITableViewCell();
                };
                
                
                // Asigna los datos de la categoría a la celda correspondiente
                let categoria = self.categorias[indexPath.row]
                cell.textLabel?.text = categoria.Nombre?.trimmingCharacters(in: .whitespacesAndNewlines);
                // Devuelve la celda configurada
                return cell
            }
            
        
}//end class
