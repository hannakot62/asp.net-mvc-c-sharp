using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pic6.Models;
using pic6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pic6.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly PurchaseRepository _purchaseRepository;

        public PurchaseController(PurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        // Отображение списка покупок
        public IActionResult Index()
        {
            var purchases = _purchaseRepository.GetPurchases();
            return View(purchases); // передача модели покупок в представление
        }

        // Показать форму для создания покупки
        public IActionResult Create()
        {
            return View();
        }

        // Обработка создания покупки
        [HttpPost]
        public IActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _purchaseRepository.SavePurchase(purchase);
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        // Показать форму для редактирования покупки
        public IActionResult Edit(int id)
        {
            var purchase = _purchaseRepository.GetPurchaseById(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        // Обработка редактирования покупки
        [HttpPost]
        public IActionResult Edit(int id, Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _purchaseRepository.UpdatePurchase(purchase);
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        // Удаление покупки
        public IActionResult Delete(int id)
        {
            var purchase = _purchaseRepository.GetPurchaseById(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _purchaseRepository.DeletePurchaseById(id);
            return RedirectToAction("Index");
        }
    }

}
