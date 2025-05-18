using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Project.Models;

namespace OOP_Project.DTO
{
    public static class DtoConverters
    {
        public static FilmDto ToDto(this Film film) => new FilmDto
        {
            Name = film.Name,
            AgeRestriction = film.AgeRestriction,
            Year = film.Year,
            OriginalTitle = film.OriginalTitle,
            Director = film.Director,
            Language = film.Language,
            Genre = film.Genre,
            Duration = film.Duration,
            Production = film.Production,
            Studio = film.Studio,
            Description = film.Description
        };

        public static Film FromDto(this FilmDto dto) => new Film(
            dto.Name, dto.AgeRestriction, dto.Year, dto.OriginalTitle, dto.Director,
            dto.Language, dto.Genre, dto.Duration, dto.Production, dto.Studio, dto.Description);

        public static TicketDto ToDto(this Ticket ticket) => new TicketDto
        {
            TicketId = ticket.TicketId,
            RowNumber = ticket.Row,
            SeatNumber = ticket.Seat,
            OwnerLogin = ticket.Owner?.Login,
            FilmName = ticket.Screening?.Film?.Name,     // нове
            ScreeningDate = ticket.Screening?.Date ?? default
        };

        public static Ticket FromDto(this TicketDto dto, Screening screening) =>
            new Ticket(screening, dto.TicketId, dto.RowNumber, dto.SeatNumber);

        public static ScreeningDto ToDto(this Screening screening) => new ScreeningDto
        {
            Film = screening.Film.ToDto(),
            Date = screening.Date,
            Tickets = screening.Tickets.Select(t => t.ToDto()).ToList()
        };

        public static Screening FromDto(this ScreeningDto dto)
        {
            var film = dto.Film.FromDto();
            var screening = new Screening(film, dto.Date);
            var tickets = dto.Tickets.Select(t => t.FromDto(screening)).ToList();
            screening.AddTickets(tickets);
            return screening;
        }

        public static ScreeningScheduleDto ToDto(this ScreeningSchedule schedule) => new ScreeningScheduleDto
        {
            Film = schedule.Film.ToDto(),
            Screenings = schedule.Screenings.Select(s => s.ToDto()).ToList()
        };

        public static ScreeningSchedule FromDto(this ScreeningScheduleDto dto)
        {
            var film = dto.Film.FromDto();
            var schedule = new ScreeningSchedule(film);

            foreach (var screeningDto in dto.Screenings)
            {
                if (screeningDto.Date >= DateTime.Now)
                {
                    var screening = screeningDto.FromDto();
                    schedule.Add(screening);
                }
            }

            return schedule;
        }


        public static RegisteredUserDto ToDto(this RegisteredUser user) => new RegisteredUserDto
        {
            Login = user.Login,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            DateOfBirth = user.DateOfBirth,
            PurchasedTickets = user.PurchasedTickets.Select(t => t.ToDto()).ToList()
        };

        public static RegisteredUser FromDto(this RegisteredUserDto dto)
        {
            var user = new RegisteredUser(dto.Login, dto.Password, dto.PhoneNumber, dto.DateOfBirth);

            foreach (var dtoTicket in dto.PurchasedTickets)
            {
                var screening = AppData.Schedules
                    .FirstOrDefault(s => s.Film.Name == dtoTicket.FilmName)?
                    .Screenings.FirstOrDefault(sc => sc.Date == dtoTicket.ScreeningDate);

                if (screening != null)
                {
                    var ticket = screening.Tickets
                        .FirstOrDefault(t => t.Row == dtoTicket.RowNumber && t.Seat == dtoTicket.SeatNumber);

                    if (ticket != null)
                    {
                        ticket.AssignToUser(user);
                    }
                }
            }

            return user;
        }

    }
}
