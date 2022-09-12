using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Exceptions; 
public class AlbumForm {
public string Title { get; set; }
public IList<IFormFile> Files { get; set; }
}

public class Album {
public Guid Id { get; set; }
public string Title { get; set; }
}

public class ImageAlbum : Controller {
//private IDatabase db;

//[HttpPost]
//public IActionResult UploadNaive(AlbumForm form) {
//  var album = db.CreateAlbum(form.Title);
//  //uploadImage(album.Id, )
//}
}
